using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Queries;
using ParkerPlan.QueryHandlers;
using ParkerPlan.Repositories;

namespace ParkerPlan.Web.Data
{
    public class GoodsService
    {
        public GoodDto[] GetAll()
        {
            return new GetGoodsQueryHandler(new SqlGoodRepository()).Execute(new GetGoods());
        }
    }
}