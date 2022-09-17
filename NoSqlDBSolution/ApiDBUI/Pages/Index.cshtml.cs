using ApiDBUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ApiDBUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGet()
        {
            await GetAllContacts();
        }

        private async Task CreateContact()
        {
            ContactModel contactModel = new ContactModel
            {
                FirstName = "Mate",
                LastName = "Toth"
            };
            contactModel.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tothmat@outlook.hu" });
            contactModel.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "test@outlook.hu" });
            contactModel.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "06203837701" });
            contactModel.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "1234567789" });


            var _client = _httpClientFactory.CreateClient();


            var response = await _client.PostAsync(
                "https://localhost:7246/api/Contacts", 
                new StringContent(JsonSerializer.Serialize(contactModel), Encoding.UTF8, "application/json"));
        }

        private async Task GetAllContacts()
        {
            var _client = _httpClientFactory.CreateClient();
            var response = await _client.GetAsync("https://localhost:7246/api/Contacts");

            List<ContactModel> contacts; 
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string responseText = await response.Content.ReadAsStringAsync();
                contacts = JsonSerializer.Deserialize<List<ContactModel>>(responseText, options);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}