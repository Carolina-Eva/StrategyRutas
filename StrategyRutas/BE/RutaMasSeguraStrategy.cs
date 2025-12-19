namespace BE
{
    public class RutaMasSeguraStrategy: RutaAStarBase
    {
        public string Nombre => "Ruta Más Segura";
        protected override int CalcularCosto(Arista arista) => arista.Riesgo;
    }
}
