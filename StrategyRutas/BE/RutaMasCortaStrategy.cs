namespace BE
{
    public class RutaMasCortaStrategy : RutaAStarBase
    {
        public string Nombre => "Ruta Más Corta";
        protected override int CalcularCosto(Arista arista) => arista.Distancia;
    }
}
