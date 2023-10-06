using CloudCustomers.API.Models;
using System.Net;

namespace CloudCustomers.API.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;
        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("https://example.com.do");

            if(response.StatusCode == HttpStatusCode.NotFound) 
                return Enumerable.Empty<User>().ToList();

            var allUsers = await response.Content.ReadFromJsonAsync<List<User>>();

            return allUsers;
        }

    }
}
