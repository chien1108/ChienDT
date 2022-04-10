using LecturerManagement.Server.UI.Services.Base;
using System.Threading.Tasks;

namespace LecturerManagement.Server.UI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<APIResponse<string>> Login(AccountLoginDto loginRequest);

        Task Logout();
    }
}