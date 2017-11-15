using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    internal class OrderConverter
    {
        internal Order Convert(OrderBO order)
        {
            return new Order()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate
            };

        }

        internal OrderBO Convert(Order order)
        {
            return new OrderBO()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate
            };

        }
    }
}
