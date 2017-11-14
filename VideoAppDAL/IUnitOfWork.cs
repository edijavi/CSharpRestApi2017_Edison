using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        IOrderRepository OrderRepository { get; }

        int Complete();
    }
}
