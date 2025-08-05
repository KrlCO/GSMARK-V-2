using GSMARK_V2.Interfaces;
using GSMARK_V2.Models;
using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace GSMARK_V2.Repository
{
    public class TCVENTRepository : ITCVENTRepository
    {
        private readonly string _repository;
        //private readonly TCVENTRepository _repository;

        public TCVENTRepository(IConfiguration configuration)
        {
            _repository = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TCVENT>> GetVentsAsync()
        {
            var ventas = new List<TCVENT>();

            using var connection = new SqlConnection(_repository);
            await connection.OpenAsync();

            var query = @"
            SELECT TOP 100 * 
            FROM TCVENT 
            ORDER BY FE_USUA_CREA";
            await using var command = new SqlCommand(query, connection);
            await using var reader = await command.ExecuteReaderAsync();
          
                        while (await reader.ReadAsync())
                        {
                            var venta = new TCVENT
                            {
                                CO_SEDE = reader["CO_SEDE"].ToString(),
                                CO_LINE_NEGO = Convert.ToInt32(reader["CO_LINE_NEGO"]),
                                NU_SECU = reader["NU_SECU"].ToString(),
                                CO_VEND = reader["CO_VEND"].ToString(),
                                FE_VENT = Convert.ToDateTime(reader["FE_VENT"]),
                                CA_TOTA_VENT = Convert.ToInt32(reader["CA_TOTA_VENT"]),
                                IM_TOTA_VENT = Convert.ToDecimal(reader["IM_TOTA_VENT"]),
                                TI_LIQI_REFE = reader["TI_LIQI_REFE"] != DBNull.Value
                                       ? reader["TI_LIQI_REFE"].ToString()
                                       : null,
                                NU_LIQI_REFE = reader["NU_LIQI_REFE"] != DBNull.Value
                                       ? reader["NU_LIQI_REFE"].ToString()
                                       : null,
                                CO_USUA_CREA = reader["CO_USUA_CREA"].ToString(),
                                FE_USUA_CREA = Convert.ToDateTime(reader["FE_USUA_CREA"]),
                                CO_USUA_MODI = reader["CO_USUA_MODI"].ToString(),
                                FE_USUA_MODI = Convert.ToDateTime(reader["FE_USUA_MODI"]),
                                NU_TURN = Convert.ToByte(reader["NU_TURN"])
                            };
                            ventas.Add(venta);
                        }
                return ventas;
        }
    }
}
