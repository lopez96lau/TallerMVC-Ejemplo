namespace Ejercicio_1.Modelo
{
    public sealed class CuentaAdvance : TipoCuenta
    {
        public CuentaAdvance()
        {
            this.nombreTipo = "ADVANCE";
            this.maxDepositos = 7500.0;
            this.maxExtracciones = 1500.0;
            this.maxTransferencias = 2000.0;
        }
    }
}