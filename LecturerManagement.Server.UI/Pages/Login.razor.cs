using Blazored.LocalStorage;
using Blazored.Toast.Services;
using LecturerManagement.Server.UI.Services.AuthServices;
using LecturerManagement.Server.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace LecturerManagement.Server.UI.Pages
{
    public partial class Login : ComponentBase
    {
        private AccountLoginDto LoginModel = new AccountLoginDto();

        [Inject] private IAuthService AuthService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }
        private async Task HandleLogin()
        {
            try
            {
                var response = await AuthService.Login(LoginModel);
                if (response.Success)
                {
                    //LocalStorage.SetItemAsync<string>("Name",)
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