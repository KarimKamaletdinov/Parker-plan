using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Worker;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Worker
{
    public class DeleteWorkerCommandHandler : ICommandHandler<DeleteWorker>
    {
        private readonly SqlWorkerRepository _repository;

        public DeleteWorkerCommandHandler(SqlWorkerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteWorker command)
        {
            _repository.Delete(command.WorkerId);
        }
    }
}