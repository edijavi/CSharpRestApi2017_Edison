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

        public IOrderService OrderService
        {
            get { return new OrderService(new DALFacade()); }
        }

        public IAddressService AddressService
        {
            get { return new AddressService(new DALFacade()); }
        }
    }
}
