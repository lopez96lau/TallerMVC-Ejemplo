namespace Ejercicio_1.Modelo
{
    public sealed class CuentaBusiness : TipoCuenta
    {
        public CuentaBusiness()
        {
            this.nombreTipo = "BUSINESS";
            this.maxDepositos = 15000.0;
            this.maxExtracciones = 2000.0;
            this.maxTransferencias = 3000.0;
        }
    }
}