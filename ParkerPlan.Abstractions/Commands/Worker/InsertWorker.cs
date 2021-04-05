using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Worker
{
    public class InsertWorker : Command
    {
        public WorkerDto Worker { get; set; }
    }
}