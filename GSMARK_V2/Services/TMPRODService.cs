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
        private readonly string _serviceTMPROD;

        public TMPRODService(IConfiguration configuration)
        {
            _serviceTMPROD = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TMPRODDTO>> GetProductsAsync(string isopvend)
        {
            using var connection = new SqlConnection(_serviceTMPROD);

            var parameters = new { ISOP_VEND = isopvend };

            var products = await connection.QueryAsync<TMPRODDTO>(
                "SP_TMPROD_Q02",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return products;
        }

    }
}
