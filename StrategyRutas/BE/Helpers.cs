namespace BE
{
    internal class Helpers
    {
        public int CalcularHeuristica(Nodo actual, Nodo destino)
        {
            //Manhattan
            int dx = actual.X - destino.X;
            int dy = actual.Y - destino.Y;
            return (int)Math.Sqrt(dx * dx + dy * dy);
        }

        public Ruta ReconstruirRuta(NodoAStar nodoFinal)
        {
            var ruta = new Ruta();
            var actual = nodoFinal;

            while (actual != null)
            {
                ruta.Nodos.Insert(0, actual.Nodo);

                if (actual.Padre != null)
                {
                    var arista = actual.Padre.Nodo.Aristas
                        .First(a => a.Destino == actual.Nodo);

                    ruta.DistanciaTotal += arista.Distancia;
                    ruta.CostoTotal += arista.Costo;
                    ruta.RiesgoTotal += arista.Riesgo;
                    ruta.TraficoTotal += arista.Trafico;
                }

                actual = actual.Padre;
            }

            ruta.PesoFinal = nodoFinal.G;
            return ruta;
        }

    }
}
