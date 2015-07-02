using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BritishProverbs.Domain.Models;
using Microsoft.Framework.OptionsModel;

namespace BritishProverbs.Domain
{
    public class BritishProverbsContext
    {
        private readonly string _connectionString;

        public BritishProverbsContext(IOptions<DomainSettings> domainOptionsAccessor)
        {
            _connectionString = domainOptionsAccessor.Options.ConnectionString;
        }

        public async Task<ProverbModel> GetRandomAsync()
        {
            const string selectStatement = "EXEC dbo.SelectRandomProverb";
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = selectStatement;
                    cmd.CommandType = CommandType.Text;

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        return reader.Select(r => ProverbModelBuilder(r)).First();
                    }
                }
            }
        }

        private async Task RecordVisit(string ipAddress)
        {
            const string insertStatement = "INSERT INTO Visits(IpAddress, CreatedOn) VALUES(@IpAddress, @CreatedOn)";

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(insertStatement, conn))
                {
                    cmd.Parameters.Add("IpAddress", SqlDbType.NVarChar).Value = ipAddress;
                    cmd.Parameters.Add("CreatedOn", SqlDbType.DateTimeOffset).Value = DateTimeOffset.Now;

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private ProverbModel ProverbModelBuilder(SqlDataReader reader)
        {
            return new ProverbModel
            {
                Id = int.Parse(reader["Id"].ToString()),
                Content = reader["Content"] is DBNull ? null : reader["Content"].ToString()
            };
        }
    }
}