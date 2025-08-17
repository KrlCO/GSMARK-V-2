using Dapper;
using GSMARK_V2.DTO;
using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;
using System.Data;
using System.Data.SqlClient;

namespace GSMARK_V2.Services
{
    public class TMPRODService : ITMPRODService
    {
        private readonly ITMPRODRepository _service;

        public TMPRODService(ITMPRODRepository repository)
        {
            _service = repository;
        }


        public async Task<IEnumerable<TMPRODDTO>> GetProductsAsync(string isopvend)
        {
            var products = await _service.GetProductsAsync(isopvend);
            var productDtos = products.Select(p => new TMPRODDTO
            {
                CO_PROD = p.CO_PROD,
                CO_ITEM_REFE = p.CO_ITEM_REFE,
                DE_ITEM = p.DE_ITEM,
                DE_PROD = p.DE_PROD,
                IM_PREC_UNIT = p.IM_PREC_UNIT,
            });

            return productDtos;
        }

        //public async Task<IEnumerable<TMPROD>> GetProductsAsync(string isopVend)
        //{
        //    return await _repository.GetProductsAsync(isopVend);
        //}

        public async Task<TMITEM?> GetProdByCodItemASync(string code)
        {
            return await _service.GetProdByCodItemASync(code);
        }

        public async Task<string> GetNextCoProdAsync()
        {
            return await _service.GetNextCoProdAsync();
        }
    }
}
