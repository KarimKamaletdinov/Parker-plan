using System;
using ParkerPlan.Abstractions.Enums;

namespace ParkerPlan.Site.Data
{
    public class EnumParser
    {
        public DeliveryMethod ParseDeliveryMethod(string value)
        {
            switch (value)
            {
                case "Нашим курьером":
                    return DeliveryMethod.OurDeliverer;
                case "Курьером СДЭК":
                    return DeliveryMethod.OurDeliverer;
                case "Из пункта выдачи":
                    return DeliveryMethod.OurDeliverer;
                case "Нашим курьером":
                    return DeliveryMethod.OurDeliverer;
            }

            throw new Exception("Такого не бывает!!!");
        }
    }
}