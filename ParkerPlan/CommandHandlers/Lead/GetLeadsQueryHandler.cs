using System.Linq;
using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Lead;
using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Queries;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Lead
{
    public class GetLeadsQueryHandler : IQueryHandler<GetLeads, LeadDto[]>
    {
        private SqlLeadRepository _repository;

        public GetLeadsQueryHandler(SqlLeadRepository repository)
        {
            _repository = repository;
        }

        public LeadDto[] Execute(GetLeads command)
        {
            return _repository.GetAll().Select(x => new LeadDto()
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                CustomerPhone = x.CustomerPhone,
                Region = x.Region,
                Sity = x.Sity,
                Street = x.Street,
                House = x.House,
                Flat = x.Flat,
                Agreed = x.Agreed,
                Payed = x.Payed,
                Delivered = x.Delivered,
                Goods = x.Goods,
                CreatingDate = x.CreatingDate,
                DeliveryDate = x.DeliveryDate,
                DeliveryMethod = x.DeliveryMethod,
                PayMethod = x.PayMethod,
                Comment = x.Comment
            }).ToArray();
        }
    }
}