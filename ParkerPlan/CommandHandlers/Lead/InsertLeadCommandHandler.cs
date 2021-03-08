using System.Linq;
using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Lead;
using ParkerPlan.Abstractions.Dtos;
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
                PenIds = command.Lead.PenIds,
                CreatingDate = command.Lead.CreatingDate,
                DeliveryDate = command.Lead.DeliveryDate,
                DeliveryMethod = command.Lead.DeliveryMethod,
                PayMethod = command.Lead.PayMethod,
                Comment = command.Lead.Comment
            });
        }
    }

    public class UpdateLeadCommandHandler : ICommandHandler<UpdateLead>
    {
        private SqlLeadRepository _repository;

        public UpdateLeadCommandHandler(SqlLeadRepository repository)
        {
            _repository = repository;
        }

        public void Execute(UpdateLead command)
        {
            _repository.Update(new Models.Lead
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
                PenIds = command.Lead.PenIds,
                CreatingDate = command.Lead.CreatingDate,
                DeliveryDate = command.Lead.DeliveryDate,
                DeliveryMethod = command.Lead.DeliveryMethod,
                PayMethod = command.Lead.PayMethod,
                Comment = command.Lead.Comment
            });
        }
    }

    public class DeleteLeadCommandHandler : ICommandHandler<DeleteLead>
    {
        private SqlLeadRepository _repository;

        public DeleteLeadCommandHandler(SqlLeadRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteLead command)
        {
            _repository.Delete(command.LeadId);
        }
    }
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
                PenIds = x.PenIds,
                CreatingDate = x.CreatingDate,
                DeliveryDate = x.DeliveryDate,
                DeliveryMethod = x.DeliveryMethod,
                PayMethod = x.PayMethod,
                Comment = x.Comment
            }).ToArray();
        }
    }
}