using System.Collections.Generic;
using Newtonsoft.Json;

namespace LaziLofiWeb.Models
{
    public class VideosResponse
    {
        [JsonProperty("videos")]
        public IEnumerable<Video> Videos { get; set; }
    }
}
