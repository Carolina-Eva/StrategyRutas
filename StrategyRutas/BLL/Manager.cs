using DAL;
using BE;

namespace BLL
{
    public class Manager
    {
        private Repository _repository = new Repository();

        public async Task<bool> GuardarRutaAsync(RutaCalculada ruta)
        {
            return await _repository.GuardarRuta(ruta);
        }

        public async Task<List<RutaCalculada>> ListarRutasAsync()
        {
            return await _repository.ListarRutas();
        }
    }
}
