using Dapper;
using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;
using MudBlazor.State.Builder;
using System.Data;
using System.Data.SqlClient;

namespace GSMARK_V2.Repository
{
    public class TMPRODRepository: ITMPRODRepository
    {
        private readonly IConfiguration _configuration;

        private string CO_EMPR = "18"; //Hardcoding Cod empresa

        public TMPRODRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        //Obtiene la lista de productos
        public async Task<IEnumerable<TMPROD>> GetProductsAsync(string isopVend)
        {
            using var connection = CreateConnection();
            var parameters = new { ISOP_VEND = isopVend };
            var productos = await connection.QueryAsync<TMPROD>(
                "SP_TMPROD_Q02",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return productos;
        }


        //Obtiene productos por ID
        public async Task<TMITEM?> GetProdByCodItemASync(string code)
        {
            using var connection = CreateConnection();
            var parameters = new { ISCO_EMPR = CO_EMPR, @ISCO_ITEM  = code };
            var item = await connection.QueryFirstOrDefaultAsync<TMITEM>("SP_TMPROD_Q05", parameters, commandType: CommandType.StoredProcedure);
            return item;
        }


        //Reigstra producto
        public async Task<int> InsertProductAsync(TMPROD product)
        {
            using var connection = CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@CO_PROD", product.CO_PROD);
            parameters.Add("CO_ITEM_REFE", product.CO_ITEM_REFE);
            parameters.Add("@DE_ITEM_ORIG", product.DE_ITEM_ORIG);
            parameters.Add("@DE_PROD", product.DE_PROD);
            parameters.Add("@INIM_PREC_UNIT", product.IM_PREC_UNIT);

            return await connection.ExecuteAsync(
                "SP_TMPROD_I01", parameters, commandType: CommandType.StoredProcedure);

        }

        //Actualiza producto
        public Task<int> UpdateProductAsync(TMPROD product)
        {
            throw new NotImplementedException();
        }

        //Elimina producto
        public Task<int> DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

  
    }
}
