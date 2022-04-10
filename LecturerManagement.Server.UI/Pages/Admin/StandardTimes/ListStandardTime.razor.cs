using Blazored.Toast.Services;
using LecturerManagement.Server.UI.Components;
using LecturerManagement.Server.UI.Services.Base;
using LecturerManagement.Server.UI.Services.StandardTimeServices;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.Server.UI.Pages.Admin.StandardTimes
{
    public partial class ListStandardTime : ComponentBase
    {
        [Inject] IClient Client { get; set; }
        [Inject] private IStandardTimeService Service { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private IJSRuntime JS { get; set; }
        private List<GetStandardTimeDto> ListStandardTimeFromApi;
        protected Confirmation DeleteConfirmation { get; set; }
        private string Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            await GetStandardTime();
        }

        private async Task GetStandardTime()
        {
            var response = await Service.GetAllStandardTime();
            if (response.Success)
            {
                ListStandardTimeFromApi = response.Data;
            }
        }

        public void OnDeleteStandardTime(string deleteId)
        {
            Id = deleteId;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteStandardTime(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                //var response = await Service.DeleteStandardTime(Id);
                var response = await Client.DeleteStandardTimeByIdAsync(Id);
                if (response.Success)
                {
                    ToastService.ShowSuccess("Delete Successs");
                    await GetStandardTime();
                    StateHasChanged();
                }
                else
                {
                    ToastService.ShowError($"Delete Error {response.Message}");
                    StateHasChanged();
                }
            }
        }
    }
}