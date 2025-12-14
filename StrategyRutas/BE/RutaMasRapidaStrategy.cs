namespace BE
{
    public class RutaMasRapidaStrategy : RutaAStarBase
    {
        protected override int CalcularCosto(Arista arista) => arista.Distancia + arista.Trafico;

    }
}
