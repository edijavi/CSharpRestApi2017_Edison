using System;
using System.Collections.Generic;
using VideoAppDAL;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;
using System.Linq;
using VideoAppBLL.Converters;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter conv = new VideoConverter();

        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(conv.Convert(vid));
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Video ->VideoBO
                //return uow.VideoRepository.GetAll();
                //Se usa landa expresion pero se puede simplificar
                return uow.VideoRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.Get(vid.Id);
                if (videoFromDb == null)
                {
                    throw new InvalidOperationException("Video not found");
                }

                videoFromDb.VideoName = vid.VideoName;
                videoFromDb.VideoType = vid.VideoType;
                videoFromDb.VideoLocation = vid.VideoLocation;
                uow.Complete();
                return conv.Convert(videoFromDb);

            }
        }


    }
}
