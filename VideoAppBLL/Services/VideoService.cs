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
        AddressConverter aConv = new AddressConverter();

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

        public void CreateAll(List<VideoBO> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var video in videos)
                {
                    uow.VideoRepository.Create(conv.Convert(video));
                }
                uow.Complete();
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
                //1. Get and convert the video
                var vid = conv.Convert(uow.VideoRepository.Get(Id));


                //2. Get All related Addresses from AddressRepository using addressIds
                //3. Convert and Add the Addresses to the CustomerBo
                /*vid.Addresses = vid.AddressIds?
                        .Select(id => aConv.Convert(uow.AddressRepository.Get(id)))
                        .ToList();
                */

                vid.Addresses = uow.AddressRepository.GetAllById(vid.AddressIds)
                    .Select(a => aConv.Convert(a))
                    .ToList();

                //4. Return the Customer
                return vid;
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

                var videoUpdated = conv.Convert(vid);
                videoFromDb.VideoName = videoUpdated.VideoName;
                videoFromDb.VideoType = videoUpdated.VideoType;
                videoFromDb.VideoLocation = videoUpdated.VideoLocation;

                //1. Remove All, except the "old" ids we wanna keep  (Avoid attached issues)
                videoFromDb.Addresses.RemoveAll(
                    va => !videoUpdated.Addresses.Exists(
                        a => a.AddressId == va.AddressId &&
                        a.VideoId == va.VideoId
                        )
                    );

                //2. Remove All ids already in database from videoUpdated
                videoUpdated.Addresses.RemoveAll(
                    va => videoFromDb.Addresses.Exists(
                        a => a.AddressId == va.AddressId &&
                        a.VideoId == va.VideoId
                    ));


                //3. Add All new VideoAddresses not yet seen in the DB
                videoFromDb.Addresses.AddRange(
                    videoUpdated.Addresses);

                uow.Complete();
                return conv.Convert(videoFromDb);

            }
        }


    }
}
