namespace BE
{
    public abstract class RutaAStarBase : IRutaStrategy
    {
        Helpers helper = new Helpers();
        public Ruta CalcularRuta(Mapa mapa, Nodo origen, Nodo destino)
        {
            var abiertos = new List<NodoAStar>();
            var cerrados = new HashSet<Nodo>();

            var inicio = new NodoAStar
            {
                Nodo = origen,
                G = 0,
                H = helper.CalcularHeuristica(origen, destino)
            };

            abiertos.Add(inicio);

            while (abiertos.Any())
            {
                // Nodo con menor F
                var actual = abiertos
                    .OrderBy(n => n.F)
                    .ThenBy(n => n.H)
                    .First();

                if (actual.Nodo == destino)
                    return helper.ReconstruirRuta(actual);

                abiertos.Remove(actual);
                cerrados.Add(actual.Nodo);

                foreach (var arista in actual.Nodo.Aristas)
                {
                    var vecino = arista.Destino;

                    if (cerrados.Contains(vecino))
                        continue;

                    int gTentativo = actual.G + CalcularCosto(arista);

                    var nodoVecino = abiertos.FirstOrDefault(n => n.Nodo == vecino);

                    if (nodoVecino == null)
                    {
                        nodoVecino = new NodoAStar
                        {
                            Nodo = vecino,
                            Padre = actual,
                            G = gTentativo,
                            H = helper.CalcularHeuristica(vecino, destino)
                        };
                        abiertos.Add(nodoVecino);
                    }
                    else if (gTentativo < nodoVecino.G)
                    {
                        nodoVecino.G = gTentativo;
                        nodoVecino.Padre = actual;
                    }
                }
            }
            return new Ruta(); // No se encontró ruta
        }

        protected abstract int CalcularCosto(Arista arista);
    }
}
