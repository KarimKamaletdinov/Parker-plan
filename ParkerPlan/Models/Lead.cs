using System;
using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Enums;

namespace ParkerPlan.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Region { get; set; }
        public string Sity { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public bool Agreed { get; set; }
        public bool Payed { get; set; }
        public bool Delivered { get; set; }
        public GoodLeadDto[] Goods { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public PayMethod PayMethod { get; set; }
        public string Comment { get; set; }
        public int? FullPrice { get; set; }
        public int? CostumerId { get; set; }
    }
}
