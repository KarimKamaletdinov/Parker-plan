using System.IO;
using System.Linq;
using ParkerPlan.Abstractions;
using ParkerPlan.Abstractions.Dtos;
using ParkerPlan.Abstractions.Queries;
using ParkerPlan.QueryHandlers;

namespace ParkerPlan.Site.Data
{
    public class PriceCalculatorService
    {
        private readonly IQueryHandler<GetGoods, GoodDto[]> _getGoods;

        public PriceCalculatorService(IQueryHandler<GetGoods, GoodDto[]> getGoods)
        {
            _getGoods = getGoods;
        }

        public int GetEngravingPrice()
        {
            return int.Parse(File.ReadAllText("engraving_price.txt"));
        }

        public int CalculateFullPrice(GoodLeadDto[] dtos)
        {
            var result = 0;

            foreach (var dto in dtos)
            {
                var good = _getGoods.Execute(new GetGoods()).First(x => x.ParkerId == dto.GoodId);
                result += dto.Count * good.Price;
                if (good.AbleToEngraving && !string.IsNullOrEmpty(dto.Engraving))
                {
                    result += GetEngravingPrice();
                }
            }

            return result;
        }
    }
}