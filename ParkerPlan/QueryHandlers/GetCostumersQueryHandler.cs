using System.Linq;
using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Queries;
using ParkerPlan.Repositories;

namespace ParkerPlan.QueryHandlers
{
    public class GetCostumersQueryHandler : IQueryHandler<GetCostumers, CostumerDto[]>
    {
        private readonly SqlCostumerRepository _repository;

        public GetCostumersQueryHandler(SqlCostumerRepository repository)
        {
            _repository = repository;
        }

        public CostumerDto[] Execute(GetCostumers query)
        {
            return _repository.GetAll().Select(x => new CostumerDto
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Region = x.Region,
                Sity = x.Sity,
                Street = x.Street,
                House = x.House,
                Flat = x.Flat,
                Comment = x.Comment,
                Password = x.Password
            }).ToArray();
        }
    }
}