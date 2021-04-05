namespace ParkerPlan.Abstractions.Commands.Worker
{
    public class DeleteWorker : Command
    {
        public int WorkerId { get; set; }
    }
}