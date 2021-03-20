using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Costumer;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Costumer
{
    public class DeleteCostumerCommandHandler : ICommandHandler<DeleteCostumer>
    {
        private readonly SqlCostumerRepository _repository;

        public DeleteCostumerCommandHandler(SqlCostumerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteCostumer command)
        {
            _repository.Delete(command.CostumerId);
        }
    }
}