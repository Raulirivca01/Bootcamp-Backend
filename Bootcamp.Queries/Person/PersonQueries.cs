using Bootcamp.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.Person
{
    public class PersonQueries : IPersonQueries
    {
        private readonly string _connectionString;
        public PersonQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
        public async Task<IEnumerable<PersonViewModel>> ReadAll()
        {
            IEnumerable<PersonViewModel> result = new List<PersonViewModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<PersonViewModel>("[dbo].[Usp_Sel_Person]", commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<IEnumerable<PersonViewModel>> ReadById(int id)
        {
            IEnumerable<PersonViewModel> result = new List<PersonViewModel>();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<PersonViewModel>("[dbo].[Usp_SelById_Person]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
