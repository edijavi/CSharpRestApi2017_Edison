using VideoAppDAL.Context;
using VideoAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
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
