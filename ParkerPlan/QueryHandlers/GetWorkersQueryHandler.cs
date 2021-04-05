using System.Linq;
using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Queries;
using ParkerPlan.Repositories;

namespace ParkerPlan.QueryHandlers
{
    public class GetWorkersQueryHandler : IQueryHandler<GetWorkers, WorkerDto[]>
    {
        private readonly SqlWorkerRepository _repository;

        public GetWorkersQueryHandler(SqlWorkerRepository repository)
        {
            _repository = repository;
        }

        public WorkerDto[] Execute(GetWorkers query)
        {
            return _repository.GetAll().Select(x => new WorkerDto
            {
                About = x.About,
                Id = x.Id,
                MyLeadIds = x.MyLeadIds,
                Name = x.Name,
                Password = x.Password,
                Patronymic = x.Patronymic,
                Position = x.Position,
                Surname = x.Surname
            }).ToArray();
        }
    }
}