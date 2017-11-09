using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppBLL.BusinessObjects
{
    public class VideoBO
    {
        public int Id { get; set; }

        public string VideoName { get; set; }

        public string VideoType { get; set; }

        public string FullTitle
        {
            get { return $"{VideoName} {VideoType} {VideoLocation}"; }

        }

        public string VideoLocation { get; set; }
    }
}
