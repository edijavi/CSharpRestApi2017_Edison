using VideoAppBLL.Services;
using VideoAppDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }
    }
}
