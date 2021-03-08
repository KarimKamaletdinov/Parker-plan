using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Good
{
    public class InsertGood : Command
    {
        public GoodDto Good { get; set; }
    }
}