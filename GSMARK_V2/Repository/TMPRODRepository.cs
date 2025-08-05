using Dapper;
using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;
using System.Data.SqlClient;

namespace GSMARK_V2.Repository
{
    public class TMPRODRepository: ITMPRODRepository
    {
        private readonly string _repositoryTMPROD;

        public TMPRODRepository(IConfiguration configuration)
        {
            _repositoryTMPROD = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TMPROD>> GetProductsAsync(string isopVend)
        {
            using var connection = new SqlConnection(_repositoryTMPROD);
            var parameters = new {ISOP_VEND = isopVend};
            var productos = await connection.QueryAsync<TMPROD>(
                "SP_TMPROD_Q02",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            return productos;
        }
    }
}
