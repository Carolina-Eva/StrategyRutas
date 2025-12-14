using BE;

namespace BLL
{
    public class Navegador
    {
        private IRutaStrategy _estrategia;

        public Navegador(IRutaStrategy estrategia)
        {
            _estrategia = estrategia;
        }

        public void CambiarEstrategia(IRutaStrategy estrategia)
        {
            _estrategia = estrategia;
        }

        public Ruta CalcularRuta(Mapa mapa, Nodo origen, Nodo destino)
        {
            return _estrategia.CalcularRuta(mapa, origen, destino);
        }
    }
}
