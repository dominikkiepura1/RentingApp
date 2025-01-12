using RentingAppFrontend.Models;
using System.Net.Http.Json;

namespace RentingAppFrontend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Pobieranie listy samochodów
        public async Task<List<CarVersion>> GetCarVersionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CarVersion>>("CarVersions");
        }


        // Tworzenie rezerwacji
        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            var response = await _httpClient.PostAsJsonAsync("Reservations", reservation);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Reservation>();
        }
    }
}
