using GSMARK_V2.DTO;
using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITMPRODService
    {
        Task<IEnumerable<TMPRODDTO>> GetProductsAsync(string isopvend);
        Task<TMITEM?> GetProdByCodItemASync(string code);

        Task<int> GetNextProductIdAsync();


    }
}
