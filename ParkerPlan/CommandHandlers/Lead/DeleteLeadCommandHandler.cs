using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Lead;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Lead
{
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
}