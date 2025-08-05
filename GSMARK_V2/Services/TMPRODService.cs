using Dapper;
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

        public async Task<IEnumerable<TMPROD>> GetProductsAsync(string isopvend)
        {
            using var connection = new SqlConnection(_serviceTMPROD);
            var parameters = new {ISOP_VEND = isopvend};
            var products = await connection.QueryAsync<TMPROD>(
                "SP_TMPROD_Q02",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            return products;
        }
    }
}
