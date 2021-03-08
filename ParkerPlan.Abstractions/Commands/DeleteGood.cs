namespace ParkerPlan.Abstractions.Commands
{
    public class DeleteGood : Command
    {
        public int GoodId { get; set; }
    }
}