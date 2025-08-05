using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITMPRODService
    {
        Task<IEnumerable<TMPROD>> GetProductsAsync(string isopvend);
    }
}
