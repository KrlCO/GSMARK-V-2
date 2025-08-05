using GSMARK_V2.Models;

namespace GSMARK_V2.Interfaces
{
    public interface ITCVENTService
    {
        Task<IEnumerable<TCVENT>> GetVentsAsync();


    }
}
