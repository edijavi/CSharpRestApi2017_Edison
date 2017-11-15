using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;

namespace VideoAppBLL
{
    public interface IOrderService
    {
        //C
        OrderBO Create(OrderBO order);
        //R
        List<OrderBO> GetAll();
        OrderBO Get(int Id);
        //U
        OrderBO Update(OrderBO order);
        //D
        OrderBO Delete(int Id);
    }
}
