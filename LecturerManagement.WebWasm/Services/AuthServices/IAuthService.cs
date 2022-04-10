using LecturerManagement.Server.Services.Base;
using System.Threading.Tasks;

namespace LecturerManagement.Server.Services.AuthServices
{
    public interface IAuthService
    {
        Task<APIResponse<string>> Login(AccountLoginDto loginRequest);

        Task Logout();
    }
}