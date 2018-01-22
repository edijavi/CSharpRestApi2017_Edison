using VideoAppDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL.Context
{
    class VideoAppContext : DbContext
    {
        static DbContextOptions<VideoAppContext> options =
            new DbContextOptionsBuilder<VideoAppContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //Options That we want in Memory
        public VideoAppContext() : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoAddress>()
                .HasKey(va => new {va.AddressId, va.VideoId});

            modelBuilder.Entity<VideoAddress>()
                .HasOne(va => va.Address)
                .WithMany(a => a.Videos)
                .HasForeignKey(va => va.AddressId);

            modelBuilder.Entity<VideoAddress>()
                .HasOne(va => va.Video)
                .WithMany(v => v.Addresses)
                .HasForeignKey(va => va.VideoId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}
