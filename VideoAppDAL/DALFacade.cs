﻿using VideoAppDAL.Repositories;
using VideoAppDAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            //get { return new VideoRepositoryFakeDB(); }
            get
            {
                return new VideoRepositoryEFMemory(new Context.InMemoryContext());
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}
