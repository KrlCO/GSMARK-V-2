using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITMITEMService
    {

        Task<IEnumerable<TMITEM>> BuscarPorInicioAsync(string? descripcion);
        Task<IEnumerable<TMITEM>> BuscarPorCadenaAsync(string? descripcion);
        Task<IEnumerable<TMITEM>> BuscarPorCodigoAsync(string? codigo);

    }
}
