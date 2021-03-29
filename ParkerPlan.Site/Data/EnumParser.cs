using System;
using ParkerPlan.Abstractions.Enums;

namespace ParkerPlan.Site.Data
{
    public class EnumParser
    {
        public DeliveryMethod ParseDeliveryMethod(string value)
        {
            return value switch
            {
                "Нашим курьером" => DeliveryMethod.OurDeliverer,
                "Курьером СДЭК" => DeliveryMethod.SdekDeliverer,
                "Из пункта выдачи СДЭК" => DeliveryMethod.FromSdek,
                "Из магазина" => DeliveryMethod.FromMarket,
                _ => throw new Exception($"Ошибка чтения: {value}. VALUE может быть: " +
                    $"{ToStringDeliveryMethod(DeliveryMethod.FromMarket)}," +
                    $"{ToStringDeliveryMethod(DeliveryMethod.FromSdek)}," +
                    $"{ToStringDeliveryMethod(DeliveryMethod.OurDeliverer)}," +
                    $"{ToStringDeliveryMethod(DeliveryMethod.SdekDeliverer)},")
            };
        }

        public string ToStringDeliveryMethod(DeliveryMethod value)
        {
            return value switch
            {
                DeliveryMethod.OurDeliverer => "Нашим курьером",
                DeliveryMethod.SdekDeliverer => "Курьером СДЭК",
                DeliveryMethod.FromSdek => "Из пункта выдачи СДЭК",
                DeliveryMethod.FromMarket => "Из магазина",
                _ => throw new Exception("Такого не бывает!!!")
            };
        }
    }
}