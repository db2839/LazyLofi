using System.Collections.Generic;
using System.Threading.Tasks;
using LazyLofi.Backend.Manager.Services.Database.Models;

namespace LazyLofi.Backend.Interfaces
{
    public interface IBackendDomain
    {
        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VideoDatabaseResposne>> GetVideos(bool wantsToRefreshDatabase, string query);

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VideoDatabaseResposne>> GetVideos();

        /// <summary>
        /// Ares the there videos currently.
        /// </summary>
        /// <returns></returns>
        bool AreThereVideosCurrently();

        /// <summary>
        /// Setups the database.
        /// </summary>
        /// <returns></returns>
        void SetupDatabase();
    }
}
