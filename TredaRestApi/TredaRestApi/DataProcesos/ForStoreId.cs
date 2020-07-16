using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TredaRestApi.ModelTreda;

namespace TredaRestApi.DataProcesos
{
    public class ForStoreId
    {
        private readonly string _connectionString;

        public ForStoreId(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionStringsTreda");
        }

        private ForStore MapToValue(SqlDataReader reader)
        {
            return new ForStore()
            {
                SKU = (int)reader["SKU"],
                ProductName = reader["ProductName"].ToString(),
                Value = (decimal)reader["Value"],
                Base64Imagen = reader["Base64Imagen"].ToString(),

            };
        }


        public async Task<List<ForStore>> SPProductosPorTienda(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SPProductosPorTienda", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Store", Id));
                    var response = new List<ForStore>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }
    }
}
