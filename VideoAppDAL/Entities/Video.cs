using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string VideoName { get; set; }

        public string VideoType { get; set; }

        public string VideoLocation { get; set; }

        //Relación de uno a varios objetos
        public List<Order> Orders  { get; set; }
        public List<VideoAddress> Addresses { get; set; }
    }
}
