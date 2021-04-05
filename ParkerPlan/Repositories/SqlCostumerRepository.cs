using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using Dapper.Contrib.Extensions;
using ParkerPlan.Models;

namespace ParkerPlan.Repositories
{
    public class SqlCostumerRepository
    {
        private readonly string _connectionString;

        public SqlCostumerRepository()
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-5SKIINA\\SQLEXPRESS",
                InitialCatalog = "ParkerPlan",
                IntegratedSecurity = true
            };

            _connectionString = b.ToString();
        }

        public void Insert(Costumer costumer)
        {
            new SqlConnection(_connectionString).Insert(new SqlCostumerDto
            {
                id = costumer.Id,
                name = costumer.Name,
                phone = costumer.Phone,
                region = costumer.Region,
                sity = costumer.Sity,
                street = costumer.Street,
                house = costumer.House,
                flat = costumer.Flat,
                comment = costumer.Comment,
                password = costumer.Password
            });
        }

        public void Update(Costumer costumer)
        {
            new SqlConnection(_connectionString).Update(new SqlCostumerDto
            {
                id = costumer.Id,
                name = costumer.Name,
                phone = costumer.Phone,
                region = costumer.Region,
                sity = costumer.Sity,
                street = costumer.Street,
                house = costumer.House,
                flat = costumer.Flat,
                comment = costumer.Comment,
                password = costumer.Password
            });
        }

        public void Delete(int costumerId)
        {
            new SqlConnection(_connectionString).Delete(new SqlCostumerDto() { id = costumerId });
        }

        public Costumer[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlCostumerDto>("SELECT * FROM Costumers");

            var result = new List<Costumer>();

            foreach (var costumer in a)
            {
                result.Add(new Costumer()
                {
                    Id = costumer.id,
                    Name = costumer.name,
                    Phone = costumer.phone,
                    Region = costumer.region,
                    Sity = costumer.sity,
                    Street = costumer.street,
                    House = costumer.house,
                    Flat = costumer.flat,
                    Comment = costumer.comment,
                    Password = costumer.password
                });
            }

            return result.ToArray();
        }

        [Table("Costumers")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private class SqlCostumerDto
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string region { get; set; }
            public string sity { get; set; }
            public string street { get; set; }
            public string house { get; set; }
            public string flat { get; set; }
            public string comment { get; set; }
            public string password { get; set; }
        }
    }
}