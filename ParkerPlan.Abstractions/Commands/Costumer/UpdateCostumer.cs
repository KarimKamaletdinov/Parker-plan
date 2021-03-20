using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Costumer
{
    public class UpdateCostumer : Command
    {
        public CostumerDto Costumer;
    }
}