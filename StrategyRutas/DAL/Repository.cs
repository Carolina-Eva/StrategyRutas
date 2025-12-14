using BE;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Repository
    {
        AccesoDatos _acceso = new AccesoDatos();

        public async Task<bool> GuardarRuta(RutaCalculada ruta)
        {
            string sql = $"GUARDAR_RUTA";
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@DistanciaTotal", ruta.DistanciaTotal),
                _acceso.CrearParametro("@TraficoTotal", ruta.TraficoTotal),
                _acceso.CrearParametro("@RiesgoTotal", ruta.RiesgoTotal),
                _acceso.CrearParametro("@PesoFinal", ruta.PesoFinal),
                _acceso.CrearParametro("@OrigenY", ruta.OrigenY),
                _acceso.CrearParametro("@OrigenX", ruta.OrigenX),
                _acceso.CrearParametro("@DestinoY", ruta.DestinoY),
                _acceso.CrearParametro("@DestinoX", ruta.DestinoX),
                _acceso.CrearParametro("@Estrategia", ruta.Estrategia),
                _acceso.CrearParametro("@Fecha", ruta.Fecha)
            };
            int result = await _acceso.Escribir(sql, parametros);
            return result > 0;
        }

        public async Task<List<RutaCalculada>> ListarRutas()
        {
            string sql = $"OBTENER_RUTAS";
            var table = await _acceso.ObtenerData(sql);
            var list = new List<RutaCalculada>();

            foreach (DataRow row in table.Rows)
            {
                RutaCalculada ruta = new RutaCalculada();
                list.Add(ruta.MapeoRuta(row));
            }
            return list;
        }
    }
}
