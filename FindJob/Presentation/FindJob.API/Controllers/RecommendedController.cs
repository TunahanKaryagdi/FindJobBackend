using FindJob.Application.Features.Jobs.Dtos;
using FindJob.Application.Features.Jobs.Queries;
using FindJob.Application.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static Google.Apis.Requests.BatchRequest;

namespace FindJob.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecommendedController : ControllerBase
    {

        private readonly HttpClient _httpClient;
        private readonly string _url = "http://127.0.0.1:8000/";

        public RecommendedController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        [HttpGet("Applied/{userId}")]
        public async Task<IActionResult> GetByApplied([FromRoute] string userId)
        {
            var response = _httpClient.GetAsync(_url + "applied_recommendation/" + userId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var jobList = JsonSerializer.Deserialize<List<JobDto>>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(jobList);
            }
            return BadRequest();
        }

        [HttpGet("Profile/{userId}")]
        public async Task<IActionResult> GetByProfile([FromRoute] string userId)
        {
            var response = _httpClient.GetAsync(_url + "profile_recommendation/" + userId).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var jobList = JsonSerializer.Deserialize<List<JobDto>>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return Ok(jobList);
            }
            return BadRequest();
        }
    }
}
