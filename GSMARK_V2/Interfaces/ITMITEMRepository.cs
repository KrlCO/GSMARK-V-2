using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITMITEMRepository
    {

        Task<IEnumerable<TMITEM>> BuscarItemsAsync(string? coItem, string? deItem, string opcion);

    }
}
