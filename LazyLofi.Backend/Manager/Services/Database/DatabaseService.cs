using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LazyLofi.Backend.Manager.Configuration;
using LazyLofi.Backend.Manager.ServiceLocators;
using LazyLofi.Backend.Manager.Services.Database.Models;
using LazyLofi.Backend.Manager.Services.Youtube;

namespace LazyLofi.Backend.Manager.Services.Database
{
    internal sealed class DatabaseService
    {
        private readonly ServiceLocator serviceLocator;
        private ConfigurationBase configurationProvider;
        private DatabaseClient databaseClient;
        private YoutubeVideoService youtubeVideoService;

        private void ShouldReloadDatabaseWithNewVideos(bool wantsToRefreshDatabase, string query)
        {
            if (wantsToRefreshDatabase)
            {
                DatabaseClient.RefreshDatabase();
                var videos = YoutubeVideoService.GetVideos(query);
                DatabaseClient.LoadVideosIntoDatabase(videos);
            }
        }

        internal bool AreThereVideosCurrently() => this.DatabaseClient.AreThereVideosCurrently();

        internal ConfigurationBase ConfigurationProvider
        {
            get
            {
                return configurationProvider ??
                    (configurationProvider = serviceLocator.CreateConfigProvider());
            }
        }

        internal DatabaseClient DatabaseClient
        {
            get
            {
                return databaseClient ??
                    (databaseClient
                    = serviceLocator.CreateDatabaseClient(ConfigurationProvider.GetDatabaseConnectionString()));
            }
        }

        internal YoutubeVideoService YoutubeVideoService
        {
            get
            {
                return youtubeVideoService ??
                    (youtubeVideoService
                    = serviceLocator.CreateYoutubeVideoService(ConfigurationProvider.GetYoutubeApiKey()));
            }
        }

        public DatabaseService(ServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public async Task<IEnumerable<VideoDatabaseResposne>> GetVideos(bool wantsToRefreshDatabase, string query)
        {
            this.ShouldReloadDatabaseWithNewVideos(wantsToRefreshDatabase, query);

            var videos = await this.DatabaseClient.GetVideosFromDatabase();

            if (videos.Any())
            {
                return videos;
            }

            throw new ArgumentException("No videos found in Database, Please Restart the application");
        }

        public void SetupDatabase()
        {
            var ContinueMakingDatabase = DatabaseClient.InitializeDatabase();
            if (ContinueMakingDatabase)
            {
                var videos = YoutubeVideoService.GetVideos();
                DatabaseClient.LoadVideosIntoDatabase(videos);
            }
        }
    }
}