using System.IO;
using ParkerPlan.Abstractions.Dtos;

namespace ParkerPlan.Site.Data
{
    public class MoneyService
    {
        public int Money
        {
            get => int.Parse(File.ReadAllText("money.txt"));
            set => File.WriteAllText("money.txt", value.ToString());
        }

        public void Plus(int value)
        {
            Money += value;
        }

        public void Minus(int value)
        {
            Money -= value;
        }

        public void Plus(LeadDto lead)
        {
            if (lead.FullPrice != null)
            {
                Plus((int)lead.FullPrice);
            }
        }

        public void Minus(LeadDto lead)
        {
            if (lead.FullPrice != null)
            {
                Minus((int)lead.FullPrice);
            }
        }

        public void Plus(GoodDto good, int count, bool selfPrice)
        {
            if (selfPrice)
            {
                Plus(good.SelfPrice * count);
            }
            else
            {
                Plus(good.Price * count);
            }
        }

        public void Minus(GoodDto good, int count, bool selfPrice)
        {
            if (selfPrice)
            {
                Minus(good.SelfPrice * count);
            }
            else
            {
                Minus(good.Price * count);
            }
        }
    }
}