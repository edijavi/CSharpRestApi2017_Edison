﻿using System.Collections.Generic;
using VideoAppDAL.Context;
using System.Linq;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        VideoAppContext _context;
        public VideoRepositoryEFMemory(VideoAppContext context)
        {
            _context = context;

        }

        public Video Create(Video vid)
        {
            _context.Videos.Add(vid);
            return vid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            _context.Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }
    }
}
