using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITCVENTRepository
    {
        //List<TCVENT> GetVents();
        Task<IEnumerable<TCVENT>> GetVentsAsync();

    }
}
