using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Worker;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Worker
{
    public class UpdateWorkerCommandHandler : ICommandHandler<UpdateWorker>
    {
        private readonly SqlWorkerRepository _repository;

        public UpdateWorkerCommandHandler(SqlWorkerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(UpdateWorker command)
        {
            _repository.Insert(new Models.Worker()
            {
                About = command.Worker.About,
                Id = command.Worker.Id,
                MyLeadIds = command.Worker.MyLeadIds,
                Name = command.Worker.Name,
                Password = command.Worker.Password,
                Patronymic = command.Worker.Patronymic,
                Position = command.Worker.Position,
                Surname = command.Worker.Surname,
                Login = command.Worker.Login
            });
        }
    }
}