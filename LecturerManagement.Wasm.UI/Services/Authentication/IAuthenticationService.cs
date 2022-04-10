using LecturerManagement.Wasm.UI.Services.Base;
using System.Threading.Tasks;

namespace LecturerManagement.Wasm.UI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(AccountLoginDto loginModel);
        public Task Logout();
    }
}