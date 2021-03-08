using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Good
{
    public class UpdateGood : Command
    {
        public GoodDto Good { get; set; }
    }
}