using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;

namespace VideoAppBLL
{
    public interface IAddressService
    {
        //C
        AddressBO Create(AddressBO address);
        //R
        List<AddressBO> GetAll();
        AddressBO Get(int Id);
        //U
        AddressBO Update(AddressBO address);
        //D
        AddressBO Delete(int Id);
    }
}
