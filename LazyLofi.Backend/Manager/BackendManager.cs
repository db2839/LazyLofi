using System.Collections.Generic;
using System.Threading.Tasks;
using LazyLofi.Backend.Manager.ServiceLocators;
using LazyLofi.Backend.Manager.Services.Database;
using LazyLofi.Backend.Manager.Services.Database.Models;

namespace LazyLofi.Backend.Manager
{
    internal sealed class BackendManager
    {
        private DatabaseService databaseService;
        private ServiceLocator serviceLocator;

        internal DatabaseService DatabaseService
        {
            get
            {
                return databaseService ??
                    (databaseService
                    = serviceLocator.CreateDatabaseService());
            }
        }

        internal bool AreThereVideosCurrently() => this.DatabaseService.AreThereVideosCurrently();

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns></returns>
        internal async Task<IEnumerable<VideoDatabaseResposne>> GetVideos(bool wantsToRefreshDatabase, string query)
            => await this.DatabaseService.GetVideos(wantsToRefreshDatabase, query);

        /// <summary>
        /// Setups the database.
        /// </summary>
        /// <returns></returns>
        internal void SetupDatabase()
            => DatabaseService.SetupDatabase();

        public BackendManager(ServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }
    }
}