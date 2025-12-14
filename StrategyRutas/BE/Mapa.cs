namespace BE
{
    public class Mapa
    {
        public List<Nodo> Nodos { get; } = new();

        public Nodo? BuscarNodo(int id)
        {
            return Nodos.FirstOrDefault(n => n.Id == id);
        }
    }
}
