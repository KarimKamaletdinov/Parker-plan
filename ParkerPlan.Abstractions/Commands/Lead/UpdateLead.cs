using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Lead
{
    public class UpdateLead : Command
    {
        public LeadDto Lead { get; set; }
    }
}