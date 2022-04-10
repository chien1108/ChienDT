using Blazored.Toast.Services;
using LecturerManagement.Server.Services.AuthServices;
using LecturerManagement.Server.Services.Base;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace LecturerManagement.Server.Pages
{
    public partial class Login : ComponentBase
    {
        private AccountLoginDto LoginModel = new AccountLoginDto();

        [Inject] private IAuthService AuthService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IToastService ToastService { get; set; }

        private async Task HandleLogin()
        {
            try
            {
                var response = await AuthService.Login(LoginModel);
                if (response.Success)
                {
                    NavigationManager.NavigateTo("/");
                }
                ToastService.ShowError("Invalid Credentials, Please Try Again");
            }
            catch (ApiException aex)
            {
                if (aex.StatusCode >= 200 && aex.StatusCode <= 299)
                {
                }
                ToastService.ShowError(aex.Response);
            }
        }
    }
}