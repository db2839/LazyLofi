using System.Collections.Generic;
using System.Threading.Tasks;
using LazyLofi.Backend.Interfaces;
using LazyLofi.Backend.Manager;
using LazyLofi.Backend.Manager.ServiceLocators;
using LazyLofi.Backend.Manager.Services.Database.Models;

namespace LazyLofi.Backend
{
    public class BackendDomain : IBackendDomain
    {
        private readonly ServiceLocatorBase serviceLocator;

        private BackendManager backendManager;

        internal BackendDomain(ServiceLocatorBase serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        internal BackendManager BackendManager
        {
            get { return this.backendManager ?? (this.backendManager = this.serviceLocator.CreateBackendManager()); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackendDomain"/> class.
        /// </summary>
        public BackendDomain() : this(new ServiceLocator())
        {
        }

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VideoDatabaseResposne>> GetVideos(bool wantsToRefreshDatabase, string query) 
            =>await this.BackendManager.GetVideos(wantsToRefreshDatabase, query);

        public async Task<IEnumerable<VideoDatabaseResposne>> GetVideos() 
            => await this.BackendManager.GetVideos(false, string.Empty);

        /// <summary>
        /// Ares the there videos currently.
        /// </summary>
        /// <returns></returns>
        public bool AreThereVideosCurrently() => this.BackendManager.AreThereVideosCurrently();

        /// <summary>
        /// Setups the database.
        /// </summary>
        /// <returns></returns>
        public void SetupDatabase()
        {
            this.BackendManager.SetupDatabase();
        }
    }
}