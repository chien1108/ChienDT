using Blazored.LocalStorage;
using LecturerManagement.Server.Services.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.Server.Services.StandardTimeServices
{
    public class StandardTimeService : BaseHttpService, IStandardTimeService 
    {
        private readonly IClient client;

        public StandardTimeService(IClient client, ILocalStorageService storageService): base (client, storageService)
        {
            this.client = client;
        }

        public async Task<Response<bool>> AddStandardTime(AddStandardTimeDto standardTime)
        {
            Response<bool> response = new();

            try
            {
                await GetBearerToken();
                await client.AddStandardTimeAsync(standardTime);
            }
            catch (ApiException exception)
            {
                response = ConvertApiException<bool>(exception);
            }

            return response;
        }

        public Task<Response<bool>> DeleteStandardTime(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> EditStandardTime(string id, UpdateAdvancedLearningDto updateAdvancedLearning)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<GetStandardTimeDto>>> GetAllStandardTime()
        {
            Response<List<GetStandardTimeDto>> response;
            try
            {
                await GetBearerToken();
                var data = await client.GetAllStandardTimeAsync();
                response = new Response<List<GetStandardTimeDto>>()
                {
                    Data = data.Data.ToList(),
                    Success = data.Success,
                    Message = data.Message
                };
            }
            catch(ApiException aex)
            {
                response = ConvertApiException<List<GetStandardTimeDto>>(aex);
            }
            return response;
        }

        public Task<Response<GetAccountDto>> GetDetails(string id)
        {
            throw new NotImplementedException();
        }
    }
}
