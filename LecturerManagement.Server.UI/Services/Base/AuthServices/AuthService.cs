using Blazored.LocalStorage;
using LecturerManagement.Server.UI.CustomAuthState;
using LecturerManagement.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace LecturerManagement.Server.UI.Services.AuthServices
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
            await _authenticationStateProvider.GetAuthenticationStateAsync();
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