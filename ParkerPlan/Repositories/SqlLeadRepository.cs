using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using Dapper.Contrib.Extensions;
using ParkerPlan.Abstractions.Enums;
using ParkerPlan.Models;

namespace ParkerPlan.Repositories
{
    public class SqlLeadRepository
    {
        private readonly string _connectionString;

        public SqlLeadRepository()
        {
            var b = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-5SKIINA\\SQLEXPRESS",
                InitialCatalog = "ParkerPlan",
                IntegratedSecurity = true
            };

            _connectionString = b.ToString();
        }

        public void Insert(Lead lead)
        {
            new SqlConnection(_connectionString).Insert(new SqlLeadDto
            {
                id = lead.Id,
                customer_name = lead.CustomerName,
                customer_phone = lead.CustomerPhone,
                region = lead.Region,
                sity = lead.Sity,
                street = lead.Street,
                house = lead.House,
                flat = lead.Flat,
                agreed = lead.Agreed,
                payed = lead.Payed,
                delivered = lead.Delivered,
                creating_date = lead.CreatingDate,
                delivery_date = lead.DeliveryDate,
                delivery_method = lead.DeliveryMethod,
                pay_method = lead.PayMethod,
                comment = lead.Comment
            });
        }

        public void Update(Lead lead)
        {
            new SqlConnection(_connectionString).Update(new SqlLeadDto
            {
                id = lead.Id,
                customer_name = lead.CustomerName,
                customer_phone = lead.CustomerPhone,
                region = lead.Region,
                sity = lead.Sity,
                street = lead.Street,
                house = lead.House,
                flat = lead.Flat,
                agreed = lead.Agreed,
                payed = lead.Payed,
                delivered = lead.Delivered,
                creating_date = lead.CreatingDate,
                delivery_date = lead.DeliveryDate,
                delivery_method = lead.DeliveryMethod,
                pay_method = lead.PayMethod,
                comment = lead.Comment
            });
        }

        public void Delete(int id)
        {
            new SqlConnection(_connectionString).Delete(new SqlLeadDto() { id = id });
        }

        public Lead[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlLeadDto>("SELECT * FROM Pens");

            var result = new List<Lead>();

            foreach (var lead in a)
            {
                result.Add(new Lead
                {
                    Id = lead.id,
                    CustomerName = lead.customer_name,
                    CustomerPhone = lead.customer_phone,
                    Region = lead.region,
                    Sity = lead.sity,
                    Street = lead.street,
                    House = lead.house,
                    Flat = lead.flat,
                    Agreed = lead.agreed,
                    Payed = lead.payed,
                    Delivered = lead.delivered,
                    PenIds = new int[]
                    {
                    },
                    CreatingDate = lead.creating_date,
                    DeliveryDate = lead.delivery_date,
                    DeliveryMethod = lead.delivery_method,
                    PayMethod = lead.pay_method,
                    Comment = lead.comment
                });
            }

            return result.ToArray();
        }

        [Table("Leads")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private class SqlLeadDto
        {
            [Key]
            public int id { get; set; }
            public string customer_name { get; set; }
            public string customer_phone { get; set; }
            public string region { get; set; }
            public string sity { get; set; }
            public string street { get; set; }
            public string house { get; set; }
            public string flat { get; set; }
            public bool agreed { get; set; }
            public bool payed { get; set; }
            public bool delivered { get; set; }
            public DateTime creating_date { get; set; }
            public DateTime delivery_date { get; set; }
            public DeliveryMethod delivery_method { get; set; }
            public PayMethod pay_method { get; set; }
            public string comment { get; set; }
        }
    }
}