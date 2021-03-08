using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands
{
    public class UpdateGood : Command
    {
        public GoodDto Good { get; set; }
    }
}