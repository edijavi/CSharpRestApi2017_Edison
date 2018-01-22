using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IAddressRepository
    {
        //C
        Address Create(Address vid);
        //R
        List<Address> GetAll();
        IEnumerable<Address> GetAllById(List<int> ids);
        Address Get(int Id);

        //U
        //(No update for Repository. It will be the task of UOW)
        //D
        Address Delete(int Id);

    }
}
