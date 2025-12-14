namespace BE
{
    public interface IRutaStrategy
    {
        Ruta CalcularRuta(Mapa mapa, Nodo origen, Nodo destino);
    }
}
