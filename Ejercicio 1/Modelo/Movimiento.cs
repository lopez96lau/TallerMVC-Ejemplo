namespace Ejercicio_1.Modelo
{
    public class Movimiento
    {
        private string fecha;
        private string tipo;
        private bool estado;
        private double monto;
        private int destinoTransferencia;

        public bool Estado { get => estado; set => estado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public double Monto { get => monto; set => monto = value; }
        public int DestinoTransferencia { get => destinoTransferencia; set => destinoTransferencia = value; }

        public Movimiento(Cliente cliente, string fecha, double monto, string tipo)
        {
            if (tipo == "DEPOSITO" || tipo == "EXTRACCION")
            {
                this.Fecha = fecha;
                this.Monto = monto;
                this.Tipo = tipo;
                this.Estado = this.VerificarEstado(cliente);
                this.DestinoTransferencia = 0;
            }
        }

        public Movimiento(Cliente cliente, string fecha, double monto, Cliente destinatario)
        {
            this.Fecha = fecha;
            this.Monto = monto;
            this.Tipo = "TRANSFERENCIA";
            this.Estado = this.VerificarEstado(cliente);
            this.DestinoTransferencia = destinatario.GetNumeroCuenta();
            destinatario.SetSaldo(monto);
        }

        public string GetFecha()
        {
            return this.Fecha;
        }

        public string GetTipo()
        {
            return this.Tipo;
        }

        public bool GetEstado()
        {
            return this.Estado;
        }

        public string GetEstado(bool estado)
        {
            if (estado) return "OK";
            else return "ERROR";
        }

        public double GetMonto()
        {
            return this.Monto;
        }

        public bool VerificarEstado(Cliente cliente)
        {
            TipoCuenta tC = cliente.GetDatosCuenta(cliente.GetTipoCuenta());
            bool b = true;
            if (Tipo == "DEPOSITO" && Monto > tC.GetMaxDepositos()) b = false;
            if (Tipo == "EXTRACCION" && Monto > tC.GetMaxExtracciones()) b = false;
            if (Tipo == "TRANSFERENCIA" && Monto > tC.GetMaxTransferencias()) b = false;
            return b;
        }

        public override string ToString()
        {
            string tipoImprimir, estadoImprimir;
            if (Tipo == "DEPOSITO")
            {
                tipoImprimir = "DEPOSITO  ";
            }
            else if (Tipo == "TRANSFERENCIA")
            {
                tipoImprimir = "TRANSF.   ";
            }
            else if (Tipo == "EXTRACCION")
            {
                tipoImprimir = Tipo;
            }
            else tipoImprimir = null;

            if (Estado) estadoImprimir = "OK    ";
            else estadoImprimir = "ERROR ";

            return "[" + Fecha + "] [" + tipoImprimir + "] [" + estadoImprimir + "]  $" + Monto + PrintDestinoTransferencia();
        }

        public string PrintDestinoTransferencia()
        {
            if (Tipo == "TRANSFERENCIA") return " (#" + DestinoTransferencia + ")";
            else return "";
        }
    }
}