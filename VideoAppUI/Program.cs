using VideoAppBLL;
using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;
using System;

namespace VideoAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {
            var vid1 = new VideoBO()
            {
                VideoName = "Youtube",
                VideoType = "Fun",
                VideoLocation = "Hall 2"
            };
            //this is one kingd to write as methot
            //bllFacade.GetVideoService().Create(vid1);
            bllFacade.VideoService.Create(vid1);

            //this is other kind to write as properties
            bllFacade.VideoService.Create(new VideoBO()
            {
                VideoName = "Winter",
                VideoType = "Nature",
                VideoLocation = "Hall 3"

            });

            //Show the first video saved internally
            //Console.WriteLine($"Name:{vid1.VideoName} {vid1.VideoType}");
            string[] menuItems =
            {
                "List All Videos",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };

            //Show Menu
            //Wait for Selection
            // - Show selection or
            // - Warning and go back to menu

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideo();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;

                    default:

                        break;
                }

                selection = ShowMenu(menuItems);

            }

            Console.WriteLine("Bye Bye!");
            Console.ReadLine();

        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            if (video != null)
            {
                Console.WriteLine("Video Name: ");
                video.VideoName = Console.ReadLine();
                Console.WriteLine("Video Type: ");
                video.VideoType = Console.ReadLine();
                Console.WriteLine("Video Location: ");
                video.VideoLocation = Console.ReadLine();
                bllFacade.VideoService.Update(video);

            }
            else
            {
                Console.WriteLine("Video not found!");
            }
        }

        private static VideoBO FindVideoById()
        {
            Console.WriteLine("Insert Video Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return bllFacade.VideoService.Get(id);
        }

        private static void DeleteVideo()
        {

            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
            var response = videoFound == null ? "Video not Found!" : "Video was Deleted";
            Console.WriteLine(response);
        }

        private static void AddVideo()
        {
            Console.WriteLine("Video Name: ");
            var videoName = Console.ReadLine();
            Console.WriteLine("Video Type: ");
            var videoType = Console.ReadLine();
            Console.WriteLine("Video Location: ");
            var videoLocation = Console.ReadLine();

            bllFacade.VideoService.Create(new VideoBO()
            {
                VideoName = videoName,
                VideoType = videoType,
                VideoLocation = videoLocation
            });

        }

        private static void ListVideos()
        {
            Console.WriteLine("\nList of Videos");

            foreach (var video in bllFacade.VideoService.GetAll())
            {
                Console.WriteLine($"Id: {video.Id} Video Name: {video.VideoName} Video Type: {video.VideoType} Video Location: {video.VideoLocation}");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What do you want to do:\n ");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }


            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 5)
            {
                Console.WriteLine("You need to select number between 1-5");
            }

            Console.WriteLine("Selection: " + selection);
            return selection;
        }

    }
}
