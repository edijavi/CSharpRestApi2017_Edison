using VideoAppDAL.Repositories;
using VideoAppDAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL
{
    public class DALFacade
    {        
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
