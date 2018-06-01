namespace Ejercicio_1.Modelo
{
    public abstract class TipoCuenta
    {
        protected string nombreTipo;
        protected double maxDepositos;
        protected double maxExtracciones;
        protected double maxTransferencias;

        public string GetNombreTipo()
        {
            return nombreTipo;
        }

        public double GetMaxDepositos()
        {
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
}