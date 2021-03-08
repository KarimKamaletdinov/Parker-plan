namespace ParkerPlan.Abstractions.Commands.Lead
{
    public class DeleteLead : Command
    {
        public int LeadId { get; set; }
    }
}