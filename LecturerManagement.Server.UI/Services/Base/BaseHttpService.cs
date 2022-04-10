using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LecturerManagement.Server.UI.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient client;
        private readonly ILocalStorageService localStorageService;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            this.client = client;
            this.localStorageService = localStorageService;
        }

        //protected Response<T> ConvertApiException<T>(ApiException apiException)
        //{
        //    if (apiException.StatusCode == 400)
        //    {
        //        return new Response<T>() { Message = "Validation errors have occured.", ValidationErrors = apiException.Response, Success = false };
        //    }
        //    if (apiException.StatusCode == 404)
        //    {
        //        return new Response<T>() { Message = "The requested item could not be found.", Success = false };
        //    }

        //    if (apiException.StatusCode >= 200 && apiException.StatusCode <= 299)
        //    {
        //        return new Response<T>() { Message = "Operation Reported Success", Success = true };
        //    }

        //    return new Response<T>() { Message = "Something went wrong, please try again.", Success = false };
        //}
        protected async Task GetBearerToken()
        {
            var token = await localStorageService.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
