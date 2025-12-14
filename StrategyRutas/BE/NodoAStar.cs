namespace BE
{
    internal class NodoAStar
    {
        public Nodo Nodo { get; set; }
        public NodoAStar? Padre { get; set; }

        public int G { get; set; }  // costo acumulado
        public int H { get; set; }  // heurística
        public int F => G + H;
    }
}
