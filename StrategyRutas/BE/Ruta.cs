using System.Data;

namespace BE
{
    public class Ruta
    {
        public int Id { get; set; }
        public List<Nodo> Nodos { get; } = new();
        public TipoRuta Tipo { get; set; }
        public int DistanciaTotal { get; set; }
        public int CostoTotal { get; set; }
        public int RiesgoTotal { get; set; }
        public int TraficoTotal { get; set; }
        public int PesoFinal { get; set; }
        public string ObtenerResumen()
        {
            return $"Distancia: {DistanciaTotal} | " +
                   $"Riesgo: {RiesgoTotal} | " +
                   $"Costo: {CostoTotal} | " +
                   $"Tráfico: {TraficoTotal}";
        }
    }

    public class RutaCalculada
    {
        public int Id { get; set; }
        public string Estrategia { get; set; }

        public int OrigenX { get; set; }
        public int OrigenY { get; set; }
        public int DestinoX { get; set; }
        public int DestinoY { get; set; }

        public int DistanciaTotal { get; set; }
        public int RiesgoTotal { get; set; }
        public int TraficoTotal { get; set; }
        public int PesoFinal { get; set; }
        public DateTime Fecha { get; set; }

        public RutaCalculada MapeoRuta(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            Estrategia = row["Estrategia"]?.ToString() ?? string.Empty;
            DistanciaTotal = Convert.ToInt32(row["DistanciaTotal"]);
            RiesgoTotal = Convert.ToInt32(row["RiesgoTotal"]);
            TraficoTotal = Convert.ToInt32(row["TraficoTotal"]);
            PesoFinal = Convert.ToInt32(row["PesoFinal"]);
            Fecha = Convert.ToDateTime(row["Fecha"]);
            OrigenX = Convert.ToInt32(row["OrigenX"]);
            OrigenY = Convert.ToInt32(row["OrigenY"]);
            DestinoX = Convert.ToInt32(row["DestinoX"]);
            DestinoY = Convert.ToInt32(row["DestinoY"]);
            return this;
        }
    }


    }
