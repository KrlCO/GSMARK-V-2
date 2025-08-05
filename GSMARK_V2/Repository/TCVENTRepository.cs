using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace GSMARK_V2.Repository
{
    public class TCVENTRepository : ITCVENTRepository
    {
        private readonly string _repository;

        public TCVENTRepository(IConfiguration configuration)
        {
            _repository = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TCVENT>> GetVentsAsync()
        {
            using var connection = new SqlConnection(_repository);
            string query = @"SELECT TOP 100 * FROM TCVENT ORDER BY FE_USUA_CREA";

            var ventas = await connection.QueryAsync<TCVENT>(query);

            return ventas;
        }
    }
}
