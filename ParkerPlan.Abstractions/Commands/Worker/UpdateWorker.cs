using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Abstractions.Commands.Worker
{
    public class UpdateWorker : Command
    {
        public WorkerDto Worker { get; set; }
    }
}