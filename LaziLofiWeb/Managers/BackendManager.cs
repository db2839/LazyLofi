using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaziLofiWeb.Managers.Interfaces;
using LaziLofiWeb.Models;
using LazyLofi.Backend.Interfaces;
using LazyLofi.Backend.Manager.Constants;
using LazyLofi.Backend.Manager.Services.Database.Models;

namespace LaziLofiWeb.Managers
{
    public class BackendManager : IBackendManager
    {
        private readonly IBackendDomain backendDomain;

        public BackendManager(IBackendDomain backendDomain)
        {
            this.backendDomain = backendDomain;
        }

        public async Task<VideosResponse> GetVideos()
        {
            if (!this.backendDomain.AreThereVideosCurrently())
            {
                this.backendDomain.SetupDatabase();
            }

            var videos = await this.backendDomain.GetVideos(true, VideoSearchConstants.GetRandomQuery()).ConfigureAwait(false);

            return this.MapVideosToVideosResponse(videos);
        }

        /// <summary>
        /// Maps the videos to videos response.
        /// </summary>
        /// <param name="videos">The videos.</param>
        /// <returns></returns>
        private VideosResponse MapVideosToVideosResponse(IEnumerable<VideoDatabaseResposne> videos)
        {
            var videosResponse = new VideosResponse();

            videosResponse.Videos = from video in videos
                                    select new Video
                                    {
                                        Title = video.Title,
                                        Url = video.Url
                                    };
            return videosResponse;
        }
    }
}
