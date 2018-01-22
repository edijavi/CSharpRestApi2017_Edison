using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Entities
{
    public class VideoAddress
    {
        public int VideoId { get; set; }
        public Video Video { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
