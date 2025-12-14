namespace BE
{
    public class Nodo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool ZonaRiesgosa { get; set; }
        public bool ZonaCongestionada { get; set; }

        public List<Arista> Aristas { get; } = new();
    }
}
