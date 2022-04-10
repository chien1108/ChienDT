using LecturerManagement.Server.Components;
using LecturerManagement.Server.Services.Base;
using LecturerManagement.Server.Services.StandardTimeServices;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.Server.Pages.Admin.StandardTimes
{
    public partial class ListStandardTime : ComponentBase
    {
        [Inject] private IClient StandardTimeAPIClient { get; set; }
        [Inject] private IStandardTimeService Service { get; set; }
        public List<GetStandardTimeDto> ListStandardTimeFromApi = new List<GetStandardTimeDto>();
        protected Confirmation DeleteConfirmation { get; set; }
        private string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
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
                await StandardTimeAPIClient.DeleteStandardTimeAsync(Id);
                await GetStandardTime();
            }
        }
    }
}