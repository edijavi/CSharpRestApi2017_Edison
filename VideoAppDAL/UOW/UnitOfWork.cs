using VideoAppDAL.Context;
using VideoAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        public IOrderRepository OrderRepository { get; internal set; }
        public IAddressRepository AddressRepository { get; internal set; }
        private VideoAppContext context;

        public UnitOfWork()
        {
            context = new VideoAppContext();
            VideoRepository = new VideoRepository(context);
            OrderRepository = new OrderRepository(context);
            AddressRepository = new AddressRepository(context);
        }

        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
