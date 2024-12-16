using CoreDomain;
using CoreDomain.Users;
using Microsoft.Data.SqlClient;
using SeniorConnect.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.DataAccesLibrary
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataAccess _dataAccess;

        public AddressRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public async Task<int> SaveAddressToDBAsync(Address address)
        {
            string query = @"
                INSERT INTO [dbo].[Address] 
                ([StreetName], [HouseNumber], [Zipcode], [City], [Country]) 
                OUTPUT INSERTED.AddressId
                VALUES 
                (@StreetName, @HouseNumber, @Zipcode, @City, @Country)";

            try
            {
                using (var connection = await _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StreetName", address.StreetName);
                    command.Parameters.AddWithValue("@HouseNumber", address.HouseNumber);
                    command.Parameters.AddWithValue("@Zipcode", address.Zipcode);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@Country", address.Country);

                    // Execute the query and return the inserted AddressId
                    return (int)await command.ExecuteScalarAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving address to database: {ex.Message}");
                throw;
            }
        }

        public Task UpdateAddresssync(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
