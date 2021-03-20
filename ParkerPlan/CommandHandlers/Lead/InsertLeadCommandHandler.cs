using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Lead;
using ParkerPlan.Abstractions.Enums;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Lead
{
    public class InsertLeadCommandHandler : ICommandHandler<InsertLead>
    {
        private SqlLeadRepository _repository;

        public InsertLeadCommandHandler(SqlLeadRepository repository)
        {
            _repository = repository;
        }

        public void Execute(InsertLead command)
        {
            _repository.Insert(new Models.Lead
            {
                Id = command.Lead.Id,
                CustomerName = command.Lead.CustomerName,
                CustomerPhone = command.Lead.CustomerPhone,
                Region = command.Lead.Region,
                Sity = command.Lead.Sity,
                Street = command.Lead.Street,
                House = command.Lead.House,
                Flat = command.Lead.Flat,
                Agreed = command.Lead.Agreed,
                Payed = command.Lead.Payed,
                Delivered = command.Lead.Delivered,
                Goods = command.Lead.Goods,
                CreatingDate = command.Lead.CreatingDate,
                DeliveryDate = command.Lead.DeliveryDate,
                DeliveryMethod = command.Lead.DeliveryMethod,
                PayMethod = command.Lead.PayMethod,
                Comment = command.Lead.Comment,
                CostumerId = command.Lead.CostumerId
            });
        }
    }
}