using System.Collections.Generic;
using VideoAppDAL.Context;
using System.Linq;
using VideoAppDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace VideoAppDAL.Repositories
{
    class VideoRepository : IVideoRepository
    {
        VideoAppContext _context;
        public VideoRepository(VideoAppContext context)
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
            return _context.Videos
                .Include(v => v.Addresses)
                .FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videos
                .Include(v => v.Addresses)
                .ToList();
        }

    }
}
