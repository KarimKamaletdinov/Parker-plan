using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Costumer
{
    public class InsertCostumer : Command
    {
        public CostumerDto Costumer;
    }
}