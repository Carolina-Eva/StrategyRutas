namespace BE
{
    public class RutaMasCortaStrategy : RutaAStarBase
    {
        protected override int CalcularCosto(Arista arista) => arista.Distancia;
    }
}
