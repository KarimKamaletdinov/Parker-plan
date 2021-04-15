using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using Dapper.Contrib.Extensions;
using ParkerPlan.Models;

namespace ParkerPlan.Repositories
{
    public class SqlWorkerRepository
    {
        private readonly string _connectionString;

        public SqlWorkerRepository()
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-5SKIINA\\SQLEXPRESS",
                InitialCatalog = "ParkerPlan",
                IntegratedSecurity = true
            };

            _connectionString = b.ToString();
        }

        public void Insert(Worker worker)
        {
            new SqlConnection(_connectionString).Insert(new SqlWorkerDto
            {
                id = worker.Id,
                name = worker.Name,
                about = worker.About,
                password = worker.Password,
                patronymic = worker.Patronymic,
                position = worker.Position,
                surname = worker.Surname,
                login = worker.Login
            });

            var b = new SqlConnection(_connectionString).Query<SqlLeadWorkerDto>("SELECT * FROM " +
                "LeadWorkerRel");
            foreach (var lw in b)
            {
                new SqlConnection(_connectionString).Delete(lw);
            }

            foreach (var id in worker.MyLeadIds)
            {
                new SqlConnection(_connectionString).Update(new SqlLeadWorkerDto
                {
                    worker_id = worker.Id,
                    lead_id = id
                });
            }
        }

        public void Update(Worker worker)
        {
            new SqlConnection(_connectionString).Update(new SqlWorkerDto
            {
                id = worker.Id,
                name = worker.Name,
                about = worker.About,
                password = worker.Password,
                patronymic = worker.Patronymic,
                position = worker.Position,
                surname = worker.Surname,
                login = worker.Login
            });

            var b = new SqlConnection(_connectionString).Query<SqlLeadWorkerDto>("SELECT * FROM " +
                "LeadWorkerRel");
            foreach (var lw in b)
            {
                new SqlConnection(_connectionString).Delete(lw);
            }

            foreach (var id in worker.MyLeadIds)
            {
                new SqlConnection(_connectionString).Update(new SqlLeadWorkerDto
                {
                    worker_id = worker.Id,
                    lead_id = id
                });
            }
        }

        public void Delete(int workerId)
        {
            new SqlConnection(_connectionString).Delete(new SqlWorkerDto() { id = workerId });
        }

        public Worker[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlWorkerDto>("SELECT * FROM Workers");

            var b = new SqlConnection(_connectionString).Query<SqlLeadWorkerDto>("SELECT * FROM " +
                "LeadWorkerRel");

            var result = new List<Worker>();

            foreach (var worker in a)
            {
                result.Add(new Worker()
                {
                    Id = worker.id,
                    Name = worker.name,
                    Password = worker.password,
                    About = worker.about,
                    Patronymic = worker.patronymic,
                    Position = worker.position,
                    Surname = worker.surname,
                    MyLeadIds = b.Where(x => x.worker_id == worker.id).Select(x => x.lead_id).ToArray(),
                    Login = worker.login
                });
            }

            return result.ToArray();
        }

        [Table("Workers")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private class SqlWorkerDto
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string patronymic { get; set; }
            public string about { get; set; }
            public string position { get; set; }
            public string password { get; set; }
            public string login { get; set; }
        }


        [Table("LeadWorkerRel")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private class SqlLeadWorkerDto
        {
            [ExplicitKey]
            public int lead_id { get; set; }
            public int worker_id { get; set; }
        }
    }
}