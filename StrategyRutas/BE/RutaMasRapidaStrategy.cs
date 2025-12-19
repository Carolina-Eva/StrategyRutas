namespace BE
{
    public class RutaMasRapidaStrategy : RutaAStarBase
    {
        public string Nombre => "Ruta Más Rápida";
        protected override int CalcularCosto(Arista arista) => arista.Distancia + arista.Trafico;

    }
}
