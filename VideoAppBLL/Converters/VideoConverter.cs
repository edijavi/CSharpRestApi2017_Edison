using System.Linq;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;


namespace VideoAppBLL.Converters
{
    class VideoConverter
    {
        private AddressConverter aConv;

        public VideoConverter()
        {
            aConv = new AddressConverter();
        }

        internal Video Convert(VideoBO vid)
        {
            if (vid == null) { return null; }

            return new Video()
            {
                Id = vid.Id,
                Addresses = vid.AddressIds?.Select(aId => new VideoAddress() {
                    AddressId = aId,
                    VideoId = vid.Id
                }).ToList(),
                VideoLocation = vid.VideoLocation,
                VideoName = vid.VideoName,
                VideoType = vid.VideoType
            };

        }

        internal VideoBO Convert(Video vid)
        {
            if (vid == null) { return null; }

            return new VideoBO()
            {
                Id = vid.Id,
                AddressIds = vid.Addresses?.Select(a => a.AddressId).ToList(),
                VideoLocation = vid.VideoLocation,
                VideoName = vid.VideoName,
                VideoType = vid.VideoType
            };

        }
    }
}
