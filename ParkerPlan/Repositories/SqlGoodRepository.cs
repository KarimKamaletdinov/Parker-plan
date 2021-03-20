using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using Dapper.Contrib.Extensions;
using ParkerPlan.Abstractions.Enums;
using ParkerPlan.Models;

namespace ParkerPlan.Repositories
{
    public class SqlGoodRepository
    {
        private readonly string _connectionString;

        public SqlGoodRepository()
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-5SKIINA\\SQLEXPRESS",
                InitialCatalog = "ParkerPlan",
                IntegratedSecurity = true
            };

            _connectionString = b.ToString();
        }

        public void Insert(Good good)
        {
            new SqlConnection(_connectionString).Insert(new SqlGoodDto
            {
                parker_id = good.ParkerId,
                name = good.Name,
                collection = good.Collection,
                able_for_man = good.AbleForMan,
                able_for_woman = good.AbleForWoman,
                gold_details = good.GoldDetails,
                gold_pen = good.GoldPen,
                pen_type = good.WritingNodeType,
                price = good.Price,
                able_to_engraving = good.AbleToEngraving,
                description = good.Description,
                in_spb = good.InSpb,
                in_moscow = good.InMsk,
                in_ekt = good.InEkt,
                in_ufa = good.InUfa,
                self_price = good.SelfPrice
            });
        }

        public void Update(Good good)
        {
            new SqlConnection(_connectionString).Update(new SqlGoodDto
            {
                parker_id = good.ParkerId,
                name = good.Name,
                collection = good.Collection,
                able_for_man = good.AbleForMan,
                able_for_woman = good.AbleForWoman,
                gold_details = good.GoldDetails,
                gold_pen = good.GoldPen,
                pen_type = good.WritingNodeType,
                price = good.Price,
                able_to_engraving = good.AbleToEngraving,
                description = good.Description,
                in_spb = good.InSpb,
                in_moscow = good.InMsk,
                in_ekt = good.InEkt,
                in_ufa = good.InUfa,
                self_price = good.SelfPrice
            });
        }

        public void Delete(int id)
        {
            new SqlConnection(_connectionString).Delete(new SqlGoodDto() { parker_id = id });
        }

        public Good[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlGoodDto>("SELECT * FROM Goods");

            var result = new List<Good>();

            foreach (var good in a)
            {
                result.Add(new Good()
                {
                    ParkerId = good.parker_id,
                    Name = good.name,
                    Collection = good.collection,
                    AbleForMan = good.able_for_man,
                    AbleForWoman = good.able_for_woman,
                    GoldDetails = good.gold_details,
                    GoldPen = good.gold_pen,
                    WritingNodeType = good.pen_type,
                    Price = good.price,
                    AbleToEngraving = good.able_to_engraving,
                    Description = good.description,
                    InSpb = good.in_spb,
                    InMsk = good.in_moscow,
                    InEkt = good.in_ekt,
                    InUfa = good.in_ufa,
                    SelfPrice = good.self_price
                });
            }

            return result.ToArray();
        }

        [Table("Goods")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private class SqlGoodDto
        {
            [ExplicitKey]
            public int parker_id { get; set; }
            public string name { get; set; }
            public string collection { get; set; }
            public bool able_for_man { get; set; }
            public bool able_for_woman { get; set; }
            public bool gold_details { get; set; }
            public bool gold_pen { get; set; }
            public WritingNodeType pen_type { get; set; }
            public int price { get; set; }
            public bool able_to_engraving { get; set; }
            public string description { get; set; }
            public int in_spb { get; set; }
            public int in_moscow { get; set; }
            public int in_ekt { get; set; }
            public int in_ufa { get; set; }
            public int self_price { get; set; }
        }
    }

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