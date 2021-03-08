using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Commands;
using ParkerPlan.Abstractions.Commands.Good;
using ParkerPlan.Repositories;

namespace ParkerPlan.CommandHandlers.Good
{
    public class InsertGoodCommandHandler : ICommandHandler<InsertGood>
    {
        private SqlGoodRepository _repository;

        public InsertGoodCommandHandler(SqlGoodRepository repository)
        {
            _repository = repository;
        }

        public void Execute(InsertGood command)
        {
            _repository.Insert(new Models.Good
            {
                ParkerId = command.Good.ParkerId,
                Name = command.Good.Name,
                Collection = command.Good.Collection,
                AbleForMan = command.Good.AbleForMan,
                AbleForWoman = command.Good.AbleForWoman,
                GoldDetails = command.Good.GoldDetails,
                GoldPen = command.Good.GoldPen,
                WritingNodeType = command.Good.WritingNodeType,
                Price = command.Good.Price,
                AbleToEngraving = command.Good.AbleToEngraving,
                Description = command.Good.Description,
                InSpb = command.Good.InSpb,
                InMsk = command.Good.InMsk,
                InUfa = command.Good.InUfa,
                InEkt = command.Good.InEkt,
                SelfPrice = command.Good.SelfPrice
            });
        }
    }
}