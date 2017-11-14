using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IOrderRepository
    {
        //C
        Order Create(Order vid);
        //R
        List<Order> GetAll();
        Order Get(int Id);
        //U(No update for Repository. It will be the task of UOW)
        //D
        Order Delete(int Id);

    }
}
