using System.Net.Http; // Dla HttpClient
using System.Net.Http.Json; // Dla metod rozszerzeń JSON, np. GetFromJsonAsync i PostAsJsonAsync
using System.Threading.Tasks; // Dla Task<T>
using System.Collections.Generic; // Dla List<T>
using RentingAppFrontend.Models; // Dla klasy User, która znajduje się w folderze Models


namespace RentingAppFrontend.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("Users");
        }

        public async Task AddUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("Users", user);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error adding user");
            }
        }
    }
}
