using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands.Costumer;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Costumer
{
    public class InsertCostumerCommandHandler : ICommandHandler<InsertCostumer>
    {
        private readonly SqlCostumerRepository _repository;

        public InsertCostumerCommandHandler(SqlCostumerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(InsertCostumer command)
        {
            _repository.Insert(new Models.Costumer
            {
                Id = command.Costumer.Id,
                Name = command.Costumer.Name,
                Phone = command.Costumer.Phone,
                Region = command.Costumer.Region,
                Sity = command.Costumer.Sity,
                Street = command.Costumer.Street,
                House = command.Costumer.House,
                Flat = command.Costumer.Flat,
                Comment = command.Costumer.Comment,
                Password = command.Costumer.Password
            });
        }
    }
}