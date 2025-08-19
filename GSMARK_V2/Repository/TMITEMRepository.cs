using Dapper;
using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;
using System.Data;

namespace GSMARK_V2.Repository
{
    public class TMITEMRepository : ITMITEMRepository
    {
        private readonly IDbConnection _dbConnection;

        public TMITEMRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TMITEM>> BuscarItemsAsync(string? coItem, string? deItem, string opcion)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ISCO_AUX1", "");
            parameters.Add("@ISCO_AUX2", "");
            parameters.Add("@ISCO_AUX3", "");
            parameters.Add("@ISCO_ITEM", coItem ?? "");
            parameters.Add("@ISDE_ITEM", deItem ?? "");
            parameters.Add("@ISDE_OPCI", opcion);

            return await _dbConnection.QueryAsync<TMITEM>(
                "SP_TMITEM_Q01", parameters, commandType: CommandType.StoredProcedure
            );
        }
    }
}
