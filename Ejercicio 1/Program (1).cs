using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
     * Cosas para revisar/ajustar:
     * ---------------------------
     *  - En vez de utilizar Strings para las fechas, usar DateTime y ordenar cronologicamente para que los movimientos se realicen
     *    de manera acorde a la fecha en los que son realizados (p. ej: las transferencias solo pueden ser para fechas futuras).
     *  - Representar los numeros de telefono como uint en vez de int.
     *  - Hacer uso de structs. Implementar properties.
     *  - Sobrecargar metodos para distintos tipos de datos en ciertos campos (p. ej: que los montos puedan ser ingresados como int).
     *  - Revisar atributos que no se inicializan en constructores, ya que luego quedan como "null".
     *  - Ver como crear clases "constantes".
     *  - Diferenciar de Persona Fisica y Juridica.
     *  - Domicilio como clase.
     *  - Revisar los sealed.
     *  - Ver ANNOTATIONS.
     */

namespace Ejercicio_1
{
    public class Programa  
    {
        static void Main(string[] args)
        {
            Banco b = new Banco();
            Cliente a, j, p;

            a = b.NewCliente("Ana", "San Martin 3231", 342456158, "ana@mvc.asp", 4000.0, "STARTER");
            j = b.NewCliente("Jose", "Rivadavia 3046", 342567878, "jose@mvc.asp", 5000.0, "ADVANCE");
            p = b.NewCliente("Maxikiosco Pedrito", "Bv. Galvez 2045", 342451132, "pedrito@mvc.asp", 10000.0, "BUSINESS");

            a.AddTelefono(342505483);
            a.AddEmail("ana@google.com");
            j.AddTelefono(342511456);
            j.AddEmail("jose_m@yahoo.com");
            p.AddTelefono(342486881);
            p.AddEmail("info@maxikioscopedrito.com");
            p.AddEmail("faq@maxikioscopedrito.com");

            a.NewExtraccion("23/03/2018", 1000.0);
            a.NewDeposito("11/04/2018", 3000.0);
            a.NewExtraccion("20/04/2018", 2500.0);
            a.NewExtraccion("20/04/2018", 1000.0);

            j.NewDeposito("13/01/2018", 5000.0);
            j.NewDeposito("25/02/2018", 1500.0);
            j.NewExtraccion("01/03/2018", 1350.0);
            j.NewExtraccion("10/03/2018", 1150.0);

            p.NewDeposito("03/03/2018", 500.0);
            p.NewExtraccion("05/03/2018", 1500.0);
            p.NewTransferencia("12/03/2018", 1550.0, j);
            p.NewTransferencia("17/03/2018", 4000.0, a);
            p.NewTransferencia("17/03/2018", 2500.0, a);
            p.NewTransferencia("18/03/2018", 1500.0, a);
            p.NewDeposito("20/03/2018", 15000.0);
            p.NewDeposito("23/03/2018", 2500.0);

            b.EstadoCuenta(p);

            System.Console.Read();
        }
    }

    public class Banco
    {
        private List<Cliente> clientes = new List<Cliente>();

        public Banco() { }

        public void EstadoCuenta(int numeroCuenta) {
            Cliente c = this.BuscarCliente(numeroCuenta);
            List<Movimiento> movs = c.GetMovimientos();

            Console.WriteLine("Cuenta#: " + c.GetNumeroCuenta());
            Console.WriteLine("Cliente: " + c.GetNombre());
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("[  FECHA   ] [MOVIMIENTO] [ESTADO] [MONTO]");
            Console.WriteLine("------------------------------------------");

            foreach (Movimiento m in movs) Console.WriteLine(m.ToString());

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Saldo: $" + c.GetSaldo());

        }

        public void EstadoCuenta(Cliente cliente) {
            this.EstadoCuenta(cliente.GetNumeroCuenta());
        }

        public Cliente BuscarCliente(int numeroCuenta) {
            foreach(Cliente c in clientes)
            {
                if (c.GetNumeroCuenta() == numeroCuenta) return c;
            }
            return null;
        }

        public Cliente BuscarCliente(Cliente cliente) {
            foreach (Cliente c in clientes)
            {
                if (c.Equals(cliente)) return c;
            }
            return null;
        }

        public Cliente NewCliente(string nombre, string domicilio, int telefono, string email, double saldoInicial, string tipoCuenta) {
            Cliente aux = new Cliente(nombre, domicilio, telefono, email, saldoInicial, tipoCuenta, this);
            this.clientes.Add(aux);
            return aux;
        }

        public int CantidadClientes() {
            return clientes.Count();
        }

    }

    public class Cliente
    {
        private string nombre;
        private List<string> domicilios = new List<string>();
        private List<int> telefonos = new List<int>();
        private List<string> emails = new List<string>();
        private List<Movimiento> movimientos = new List<Movimiento>();
        private double saldo;
        private string tipoCuenta;
        private int numeroCuenta;

        public Cliente() { }

        public Cliente(string nombre, string domicilio, int telefono, string email, double saldoInicial, string tipoCuenta, Banco banco) {
            this.nombre = nombre;
            this.AddDomicilio(domicilio);
            this.AddTelefono(telefono);
            this.AddEmail(email);
            this.saldo = saldoInicial;
            this.tipoCuenta = tipoCuenta;
            this.numeroCuenta = (banco.CantidadClientes()) + 1;
        }

        public void AddDomicilio(string domicilio) {
            this.domicilios.Add(domicilio);
        }

        public void AddTelefono(int telefono) {
            this.telefonos.Add(telefono);
        }

        public void AddEmail(string email) {
            this.emails.Add(email);
        }

        public List<Movimiento> GetMovimientos() {
            return movimientos;
        }

        public string GetTipoCuenta() {
            return tipoCuenta;
        }

        public int GetNumeroCuenta() {
            return numeroCuenta;
        }

        public string GetNombre() {
            return nombre;
        }

        public double GetSaldo() {
            return saldo;
        }

        public TipoCuenta GetDatosCuenta(string tipoCuenta) {
            TipoCuenta cS = new CuentaStarter();
            TipoCuenta cA = new CuentaAdvance();
            TipoCuenta cB = new CuentaBusiness();
            switch (tipoCuenta) {
                case "STARTER": return cS;
                case "ADVANCE": return cA;
                case "BUSINESS": return cB;
                default: return null;
            }
        }

        public void SetSaldo(double newSaldo) {
            this.saldo += newSaldo;
        }

        public void NewDeposito(string fecha, double monto) {
            Movimiento aux = new Movimiento(this, fecha, monto, "DEPOSITO");
            this.movimientos.Add(aux);
            this.SetSaldo(monto);
        }

        public void NewExtraccion(string fecha, double monto) {
            Movimiento aux = new Movimiento(this, fecha, monto, "EXTRACCION");
            this.movimientos.Add(aux);
            this.SetSaldo(-monto);
        }

        public void NewTransferencia(string fecha, double monto, Cliente destinatario) {
            Movimiento aux = new Movimiento(this, fecha, monto, destinatario);
            this.movimientos.Add(aux);
            this.SetSaldo(-monto);
        }

    }

    public class Movimiento
    {
        private string fecha;
        private string tipo;
        private bool estado;
        private double monto;
        private int destinoTransferencia;

        public Movimiento(Cliente cliente, string fecha, double monto, string tipo) {
            if (tipo == "DEPOSITO" || tipo == "EXTRACCION")
            {
                this.fecha = fecha;
                this.monto = monto;
                this.tipo = tipo;
                this.estado = this.VerificarEstado(cliente);
                this.destinoTransferencia = 0;
            }
        }

        public Movimiento(Cliente cliente, string fecha, double monto, Cliente destinatario) {
            this.fecha = fecha;
            this.monto = monto;
            this.tipo = "TRANSFERENCIA";
            this.estado = this.VerificarEstado(cliente);
            this.destinoTransferencia = destinatario.GetNumeroCuenta();
            destinatario.SetSaldo(monto);       
        }

        public string GetFecha() {
            return this.fecha;
        }

        public string GetTipo() {
            return this.tipo;    
        }

        public bool GetEstado() {
            return this.estado;
        }

        public string GetEstado(bool estado) {
            if (estado) return "OK";
            else return "ERROR";
        }

        public double GetMonto() {
            return this.monto;
        }

        public bool VerificarEstado(Cliente cliente) {
            TipoCuenta tC = cliente.GetDatosCuenta(cliente.GetTipoCuenta());
            bool b = true;
            if (tipo == "DEPOSITO" && monto > tC.GetMaxDepositos()) b = false;
            if (tipo == "EXTRACCION" && monto > tC.GetMaxExtracciones()) b = false;
            if (tipo == "TRANSFERENCIA" && monto > tC.GetMaxTransferencias()) b = false;
            return b;
        }

        public override string ToString() {
            string tipoImprimir, estadoImprimir;
            if (tipo == "DEPOSITO") tipoImprimir = "DEPOSITO  ";
            if (tipo == "TRANSFERENCIA") tipoImprimir = "TRANSF.   ";
            if (tipo == "EXTRACCION") tipoImprimir = tipo;
            else tipoImprimir = null;
            if (estado) estadoImprimir = "OK    ";
            else estadoImprimir = "ERROR ";
            return "[" + fecha + "] [" + tipoImprimir + "] [" + estadoImprimir + "]  $" + monto + PrintDestinoTransferencia();
        }

        public string PrintDestinoTransferencia() {
            if (tipo == "TRANSFERENCIA") return " (#" + destinoTransferencia + ")";
            else return "";
        }

    }

    public abstract class TipoCuenta
    {
        protected string nombreTipo;
        protected double maxDepositos;
        protected double maxExtracciones;
        protected double maxTransferencias;

        public string GetNombreTipo() {
            return nombreTipo;
        }

        public double GetMaxDepositos() {
            return maxDepositos;
        }

        public double GetMaxExtracciones()
        {
            return maxExtracciones;
        }

        public double GetMaxTransferencias()
        {
            return maxTransferencias;
        }
    }

    public sealed class CuentaStarter : TipoCuenta
    {
        private new const string nombreTipo = "STARTER";
        private new const double maxDepositos = 5000.0;
        private new const double maxExtracciones = 1000.0;
        private new const double maxTransferencias = 500.0;

        public CuentaStarter() { }

    }

    public sealed class CuentaAdvance : TipoCuenta
    {
        private new const string nombreTipo = "ADVANCE";
        private new const double maxDepositos = 7500.0;
        private new const double maxExtracciones = 1500.0;
        private new const double maxTransferencias = 2000.0;

        public CuentaAdvance() { }
    }

    public sealed class CuentaBusiness : TipoCuenta
    {
        private new const string nombreTipo = "BUSINESS";
        private new const double maxDepositos = 15000.0;
        private new const double maxExtracciones = 2000.0;
        private new const double maxTransferencias = 3000.0;

        public CuentaBusiness() { }
    }
}
