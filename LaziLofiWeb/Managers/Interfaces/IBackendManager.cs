using System.Threading.Tasks;
using LaziLofiWeb.Models;

namespace LaziLofiWeb.Managers.Interfaces
{
    public interface IBackendManager
    {
        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns></returns>
        Task<VideosResponse> GetVideos();
    }
}
