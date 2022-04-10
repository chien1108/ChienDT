using Blazored.LocalStorage;
using LecturerManagement.Server.CustomAuthState;
using LecturerManagement.Server.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace LecturerManagement.Server.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IClient _apiClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(IClient httpClient, AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _apiClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<APIResponse<string>> Login(AccountLoginDto loginRequest)
        {
            var result = await _apiClient.LoginAsync(loginRequest);

            if (!result.Success)
            {
                return new APIResponse<string>() { Message = result.Message, Success = result.Success };
            }
            await _localStorage.SetItemAsync("accessToken", result!.Data);
            ((CustomApiAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.Username);

            return new APIResponse<string>() { Message = result.Message, Success = result.Success };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("accessToken");
            ((CustomApiAuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        }
    }
}