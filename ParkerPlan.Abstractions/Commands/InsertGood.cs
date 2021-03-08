using System.Dynamic;
using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands
{
    public class InsertGood : Command
    {
        public GoodDto Good { get; set; }
    }
}