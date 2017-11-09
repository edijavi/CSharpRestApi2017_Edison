using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;


namespace VideoAppBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                VideoLocation = vid.VideoLocation,
                VideoName = vid.VideoName,
                VideoType = vid.VideoType
            };

        }

        internal VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                VideoLocation = vid.VideoLocation,
                VideoName = vid.VideoName,
                VideoType = vid.VideoType
            };

        }
    }
}
