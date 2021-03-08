using System.Linq;
using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Queries;
using ParkerPlan.Repositories;

namespace ParkerPlan.QueryHandlers
{
    public class GetGoodsQueryHandler : IQueryHandler<GetGoods, GoodDto[]>
    {
        private SqlGoodRepository _repository;

        public GetGoodsQueryHandler(SqlGoodRepository repository)
        {
            _repository = repository;
        }

        public GoodDto[] Execute(GetGoods query)
        {
            return _repository.GetAll().Select(x => new GoodDto
            {
                ParkerId = x.ParkerId,
                Name = x.Name,
                Collection = x.Collection,
                AbleForMan = x.AbleForMan,
                AbleForWoman = x.AbleForWoman,
                GoldDetails = x.GoldDetails,
                GoldPen = x.GoldPen,
                WritingNodeType = x.WritingNodeType,
                Price = x.Price,
                AbleToEngraving = x.AbleToEngraving,
                Description = x.Description,
                InSpb = x.InSpb,
                InMsk = x.InMsk,
                InUfa = x.InUfa,
                InEkt = x.InEkt,
                SelfPrice = x.SelfPrice
            }).ToArray();
        }
    }
}