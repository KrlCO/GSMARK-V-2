using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITMPRODRepository
    {

        Task<IEnumerable<TMPROD>> GetProductsAsync(string isopVend);
        //Task<TMPROD?> GetProdByIdASync(string id);
        Task<TMITEM?> GetProdByCodItemASync(string code);
        Task<int> InsertProductAsync(TMPROD product);
        Task<int> UpdateProductAsync(TMPROD product);
        Task<int> DeleteProductAsync(int id);

    }
}
