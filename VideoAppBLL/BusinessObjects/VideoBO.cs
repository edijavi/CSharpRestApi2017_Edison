using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideoAppBLL.BusinessObjects
{
    public class VideoBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string VideoName { get; set; }
        public string VideoType { get; set; }
        public string VideoLocation { get; set; }

        public string FullTitle
        {
            get { return $"{VideoName} {VideoType} {VideoLocation}"; }

        }

        public List<int> AddressIds { get; set; }
        public List<AddressBO> Addresses { get; set; }
    }
}
