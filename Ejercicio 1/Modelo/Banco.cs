using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio_1.Modelo
{
    public class Banco
    {
        private List<Cliente> clientes = new List<Cliente>();

        public Banco()
        {
        }

        public void EstadoCuenta(int numeroCuenta)
        {
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

        public void EstadoCuenta(Cliente cliente)
        {
            this.EstadoCuenta(cliente.GetNumeroCuenta());
        }

        public Cliente BuscarCliente(int numeroCuenta)
        {
            foreach (Cliente c in clientes)
            {
                if (c.GetNumeroCuenta() == numeroCuenta) return c;
            }
            return null;
        }

        public Cliente BuscarCliente(Cliente cliente)
        {
            foreach (Cliente c in clientes)
            {
                if (c.Equals(cliente)) return c;
            }
            return null;
        }

        public Cliente NewCliente(string nombre, string tipo, string domicilio, int telefono, string email, double saldoInicial, string tipoCuenta)
        {
            Cliente aux = new Cliente(nombre, tipo, domicilio, telefono, email, saldoInicial, tipoCuenta, this);
            this.clientes.Add(aux);
            return aux;
        }

        public int CantidadClientes()
        {
            return clientes.Count();
        }
    }
}