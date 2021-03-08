using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Lead
{
    public class InsertLead : Command
    {
        public LeadDto Lead { get; set; }
    }
}