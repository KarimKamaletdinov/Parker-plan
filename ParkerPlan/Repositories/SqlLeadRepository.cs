using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using ParkerPlan.Abstractions.Dtos;
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
            //var max = GetAll().Max(x => x.Id) + 1;
            //lead.Id = max;
            var l = new SqlLeadDto
            {
                id = lead.Id,
                costumer_name = lead.CustomerName,
                costumer_phone = lead.CustomerPhone,
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
                comment = lead.Comment,
                costumer_id = lead.Id,
                full_price = lead.FullPrice
            };
            new SqlConnection(_connectionString).Insert(l);
            lead.Id = l.id;

            foreach (var dto in new SqlConnection(_connectionString).Query<SqlGoodLeadRelDto>(
                "SELECT * FROM LeadPenRel").Where(x => x.lead_id == lead.Id))
            {
                new SqlConnection(_connectionString).Delete(dto);
            }

            foreach (var good in lead.Goods)
            {
                new SqlConnection(_connectionString).Insert(new SqlGoodLeadRelDto()
                {
                    count = good.Count,
                    engraving = good.Engraving,
                    pen_id = good.GoodId,
                    lead_id = lead.Id
                });
            }
        }

        public void Update(Lead lead)
        {
            new SqlConnection(_connectionString).Update(new SqlLeadDto
            {
                id = lead.Id,
                costumer_name = lead.CustomerName,
                costumer_phone = lead.CustomerPhone,
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
                comment = lead.Comment,
                costumer_id = lead.CostumerId,
                full_price = lead.FullPrice
            });

            foreach (var dto in new SqlConnection(_connectionString).Query<SqlGoodLeadRelDto>(
                "SELECT * FROM LeadPenRel").Where(x => x.lead_id == lead.Id))
            {
                new SqlConnection(_connectionString).Delete(dto);
            }

            foreach (var good in lead.Goods)
            {
                new SqlConnection(_connectionString).Insert(new SqlGoodLeadRelDto()
                {
                    count = good.Count,
                    engraving = good.Engraving,
                    pen_id = good.GoodId,
                    lead_id = lead.Id
                });
            }
        }

        public void Delete(int id)
        {
            new SqlConnection(_connectionString).Delete(new SqlLeadDto() { id = id });

            foreach (var dto in new SqlConnection(_connectionString).Query<SqlGoodLeadRelDto>(
                "SELECT * FROM LeadPenRel").Where(x => x.lead_id == id))
            {
                new SqlConnection(_connectionString).Delete(dto);
            }
        }

        public Lead[] GetAll()
        {
            var a = new SqlConnection(_connectionString).Query<SqlLeadDto>("SELECT * FROM Leads");

            var result = new List<Lead>();

            foreach (var lead in a)
            {
                result.Add(new Lead
                {
                    Id = lead.id,
                    CustomerName = lead.costumer_name,
                    CustomerPhone = lead.costumer_phone,
                    Region = lead.region,
                    Sity = lead.sity,
                    Street = lead.street,
                    House = lead.house,
                    Flat = lead.flat,
                    Agreed = lead.agreed,
                    Payed = lead.payed,
                    Delivered = lead.delivered,
                    Goods = new SqlConnection(_connectionString).Query<SqlGoodLeadRelDto>("Select * FROM " +
                        "LeadPenRel").Where(x => x.lead_id == lead.id).Select(x => new GoodLeadDto()
                    {
                            GoodId = x.pen_id,
                            Engraving = x.engraving,
                            Count = x.count
                    }).ToArray(),
                    CreatingDate = lead.creating_date,
                    DeliveryDate = lead.delivery_date,
                    DeliveryMethod = lead.delivery_method,
                    PayMethod = lead.pay_method,
                    Comment = lead.comment,
                    CostumerId = lead.costumer_id,
                    FullPrice = lead.full_price
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
            public string costumer_name { get; set; }
            public string costumer_phone { get; set; }
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
            public int? costumer_id { get; set; }
            public int? full_price { get; set; }
        }

        [Table("LeadPenRel")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private class SqlGoodLeadRelDto
        {
            [ExplicitKey]
            public int lead_id { get; set; }
            [ExplicitKey]
            public int pen_id { get; set; }
            public string engraving { get; set; }
            public int count { get; set; }
        }
    }
}