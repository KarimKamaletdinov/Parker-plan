using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers
{
    public class DeleteGoodCommandHandler : ICommandHandler<DeleteGood>
    {
        private SqlGoodRepository _repository;

        public DeleteGoodCommandHandler(SqlGoodRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteGood command)
        {
            _repository.Delete(command.GoodId);
        }
    }
}