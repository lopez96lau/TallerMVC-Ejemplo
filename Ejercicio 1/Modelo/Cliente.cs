using System.Collections.Generic;

namespace Ejercicio_1.Modelo
{
    public class Cliente
    {
        private string nombre;
        private string tipo;
        private List<string> domicilios = new List<string>();
        private List<int> telefonos = new List<int>();
        private List<string> emails = new List<string>();
        private List<Movimiento> movimientos = new List<Movimiento>();
        private double saldo;
        private string tipoCuenta;
        private int numeroCuenta;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<string> Domicilios { get => domicilios; set => domicilios = value; }
        public List<int> Telefonos { get => telefonos; set => telefonos = value; }
        public List<string> Emails { get => emails; set => emails = value; }
        public List<Movimiento> Movimientos { get => movimientos; set => movimientos = value; }
        public string TipoCuenta { get => tipoCuenta; set => tipoCuenta = value; }
        public int NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public Cliente()
        {
        }

        public Cliente(string nombre, string tipo, string domicilio, int telefono, string email, double saldoInicial, string tipoCuenta, Banco banco)
        {
            this.Nombre = nombre;
            this.tipo = tipo;
            this.AddDomicilio(domicilio);
            this.AddTelefono(telefono);
            this.AddEmail(email);
            this.saldo = saldoInicial;
            this.TipoCuenta = tipoCuenta;
            this.NumeroCuenta = (banco.CantidadClientes()) + 1;
        }

        public void AddDomicilio(string domicilio)
        {
            this.Domicilios.Add(domicilio);
        }

        public void AddTelefono(int telefono)
        {
            this.Telefonos.Add(telefono);
        }

        public void AddEmail(string email)
        {
            this.Emails.Add(email);
        }

        public List<Movimiento> GetMovimientos()
        {
            return Movimientos;
        }

        public string GetTipoCuenta()
        {
            return TipoCuenta;
        }

        public int GetNumeroCuenta()
        {
            return NumeroCuenta;
        }

        public string GetNombre()
        {
            return Nombre;
        }

        public double GetSaldo()
        {
            return saldo;
        }

        public TipoCuenta GetDatosCuenta(string tipoCuenta)
        {
            TipoCuenta cS = new CuentaStarter();
            TipoCuenta cA = new CuentaAdvance();
            TipoCuenta cB = new CuentaBusiness();
            switch (tipoCuenta)
            {
                case "STARTER": return cS;
                case "ADVANCE": return cA;
                case "BUSINESS": return cB;
                default: return null;
            }
        }

        public void SetSaldo(double newSaldo)
        {
            this.saldo += newSaldo;
        }

        public void NewDeposito(string fecha, double monto)
        {
            Movimiento aux = new Movimiento(this, fecha, monto, "DEPOSITO");
            this.Movimientos.Add(aux);
            if (aux.GetEstado()) this.SetSaldo(monto);
        }

        public void NewExtraccion(string fecha, double monto)
        {
            Movimiento aux = new Movimiento(this, fecha, monto, "EXTRACCION");
            this.Movimientos.Add(aux);
            if (aux.GetEstado()) this.SetSaldo(-monto);
        }

        public void NewTransferencia(string fecha, double monto, Cliente destinatario)
        {
            Movimiento aux = new Movimiento(this, fecha, monto, destinatario);
            this.Movimientos.Add(aux);
            if (aux.GetEstado()) this.SetSaldo(-monto);
        }
    }
}