using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class OrderRepository : IOrderRepository
    {
        VideoAppContext _context;
        public OrderRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            if (order.Video !=null)
            {
                _context.Entry(order.Video).State =EntityState.Unchanged;
            }
            _context.Orders.Add(order);
            return order;

        }

        public Order Delete(int Id)
        {
            var order = Get(Id);
            _context.Orders.Remove(order);
            return order;
        }

        public Order Get(int Id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id ==Id);
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
    }
}
