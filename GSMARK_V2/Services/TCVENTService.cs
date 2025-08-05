using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;

namespace GSMARK_V2.Services
{
    public class TCVENTService: ITCVENTService
    {
        private readonly ITCVENTRepository _tcventRepository;

        public TCVENTService(ITCVENTRepository tcventRepository)
        {
            _tcventRepository = tcventRepository;

        }

        public async Task<IEnumerable<TCVENT>> GetVentsAsync()
        {
           return await _tcventRepository.GetVentsAsync();
        }

    }
}
