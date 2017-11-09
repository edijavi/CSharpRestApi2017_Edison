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
    }
}
