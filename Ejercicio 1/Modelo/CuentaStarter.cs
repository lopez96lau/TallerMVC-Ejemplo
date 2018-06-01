namespace Ejercicio_1.Modelo
{
    public sealed class CuentaStarter : TipoCuenta
    {
        public CuentaStarter()
        {
            this.nombreTipo = "STARTER";
            this.maxDepositos = 5000.0;
            this.maxExtracciones = 1000.0;
            this.maxTransferencias = 500.0;
        }
    }
}