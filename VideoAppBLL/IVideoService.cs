using VideoAppBLL.BusinessObjects;
using System.Collections.Generic;


namespace VideoAppBLL
{
    /// <summary>
    /// I made a contract!!!
    /// </summary>
    public interface IVideoService
    {
        //C
        VideoBO Create(VideoBO vid);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        //U
        VideoBO Update(VideoBO vid);
        //D
        VideoBO Delete(int Id);

    }
}
