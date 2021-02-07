using System.Threading.Tasks;
using LaziLofiWeb.Managers.Interfaces;
using LaziLofiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LaziLofiWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackendController : ControllerBase
    {
        private readonly ILogger<BackendController> _logger;

        private readonly IBackendManager backendManager;


        public BackendController(ILogger<BackendController> logger, IBackendManager backendManager)
        {
            this._logger = logger;
            this.backendManager = backendManager;
        }

        [HttpGet]
        public async Task<VideosResponse> Get() => await this.backendManager.GetVideos();
    }
}
