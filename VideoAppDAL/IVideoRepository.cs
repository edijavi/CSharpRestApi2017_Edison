using VideoAppDAL.Entities;
using System.Collections.Generic;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U(No update for Repository. It will be the task of UOW)
        //D
        Video Delete(int Id);
    }
}
