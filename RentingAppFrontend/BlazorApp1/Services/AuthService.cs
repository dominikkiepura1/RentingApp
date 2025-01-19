using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using RentingAppFrontend.Models;

namespace RentingAppFrontend.Services
{
    public class AuthService : AuthenticationStateProvider
    {
        private User _currentUser;

        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Id = 2, Username = "user", Password = "user123", Role = "User" }
        };

        public async Task<bool> Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null) return false;

            _currentUser = user;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return true;
        }

        public void Logout()
        {
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = _currentUser == null
                ? new ClaimsIdentity()
                : new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, _currentUser.Username),
                    new Claim(ClaimTypes.Role, _currentUser.Role)
                }, "TestAuth");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
