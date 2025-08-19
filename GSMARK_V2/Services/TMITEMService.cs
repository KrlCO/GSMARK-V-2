using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;

namespace GSMARK_V2.Services
{
    public class TMITEMService : ITMITEMService
    {

        private readonly ITMITEMRepository _repository;

        public TMITEMService(ITMITEMRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TMITEM>> BuscarPorInicioAsync(string? descripcion)
                   => await _repository.BuscarItemsAsync(null, descripcion, "I");

        public async Task<IEnumerable<TMITEM>> BuscarPorCadenaAsync(string? descripcion)
            => await _repository.BuscarItemsAsync(null, descripcion, "C");

        public async Task<IEnumerable<TMITEM>> BuscarPorCodigoAsync(string? codigo)
            => await _repository.BuscarItemsAsync(codigo, null, "O");
    }
}
