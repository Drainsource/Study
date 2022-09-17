using HomWorkSWAPI.Models;
using HomWorkSWAPI.Policies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWAPI.Models;
using System.Text.Json;

namespace HomWorkSWAPI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ClientPolicy _clientPolicy;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, ClientPolicy clientPolicy)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _clientPolicy = clientPolicy;
        }

        public async Task OnGet()
        {
            var client = _httpClientFactory.CreateClient();
            //var response = await client.GetAsync("https://swapi.dev/api/people/1");
            var response = await _clientPolicy.InmidateHttpRetry.ExecuteAsync(
                () => client.GetAsync("https://swapi.dev/api/people/1")
                );


            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var contexText = await response.Content.ReadAsStringAsync();
                var sWPerson = JsonSerializer.Deserialize<SWPersonModel>(contexText, options);
            }
            
        }
    }
}