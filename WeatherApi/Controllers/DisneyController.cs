using Microsoft.AspNetCore.Mvc;
using System;

namespace MSA.Phase2.AmazingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisneyController : ControllerBase
    {
        private readonly HttpClient _client;
        /// <summary />
        public DisneyController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("disney");
        }
        /// <summary>
        /// Gets the raw JSON for the hot feed in disney
        /// </summary>
        /// <returns>A JSON object representing the hot feed in disney</returns>
        [HttpGet]
        [Route("raw")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetRawRedditHotPosts()
        {
            var res = await _client.GetAsync("/hot");
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }

}


