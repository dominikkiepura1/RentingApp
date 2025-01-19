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

        // Tworzenie nowego samochodu
        public async Task<CarVersion> CreateCarVersionAsync(CarVersion carVersion)
        {
            var response = await _httpClient.PostAsJsonAsync("CarVersions", carVersion);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CarVersion>();
        }

        // Aktualizacja istniejącego samochodu
        public async Task UpdateCarVersionAsync(CarVersion carVersion)
        {
            var response = await _httpClient.PutAsJsonAsync($"CarVersions/{carVersion.Id}", carVersion);
            response.EnsureSuccessStatusCode();
        }

        // Usuwanie samochodu
        public async Task DeleteCarVersionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"CarVersions/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Tworzenie nowej rezerwacji
        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            var response = await _httpClient.PostAsJsonAsync("Reservations", reservation);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Reservation>();
        }

        // Pobieranie listy rezerwacji
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Reservation>>("Reservations");
        }

        // Pobieranie szczegółów rezerwacji
        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Reservation>($"Reservations/{id}");
        }

        // Usuwanie rezerwacji
        public async Task DeleteReservationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Reservations/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
