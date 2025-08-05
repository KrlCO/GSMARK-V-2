using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITMPRODRepository
    {

        Task<IEnumerable<TMPROD>> GetProductsAsync(string isopVend);

    }
}
