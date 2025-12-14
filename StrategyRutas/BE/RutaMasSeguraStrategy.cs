namespace BE
{
    public class RutaMasSeguraStrategy: RutaAStarBase
    {
        protected override int CalcularCosto(Arista arista) => arista.Riesgo;
    }
}
