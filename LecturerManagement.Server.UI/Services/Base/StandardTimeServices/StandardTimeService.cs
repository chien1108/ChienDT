using Blazored.LocalStorage;
using LecturerManagement.Server.UI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagement.Server.UI.Services.StandardTimeServices
{
    public class StandardTimeService : BaseHttpService, IStandardTimeService
    {
        private readonly IClient client;

        public StandardTimeService(IClient client, ILocalStorageService storageService) : base(client, storageService)
        {
            this.client = client;
        }

        public async Task<Response<bool>> AddStandardTime(AddStandardTimeDto objectBody)
        {
            Response<bool> result = new();

            try
            {
                await GetBearerToken();
                var response = await client.AddNewStandardTimeAsync(objectBody);
                result.Success = response.Success;
                result.Message = response.Message;
            }
            catch (ApiException exception)
            {
                //response = ConvertApiException<bool>(exception);
                result.Success = false;
                result.Message = exception.Message;
            }

            return result;
        }

        public async Task<Response<bool>> DeleteStandardTime(string id)
        {
            Response<bool> response = new();
            try
            {
                await GetBearerToken();
                var result = await client.DeleteStandardTimeByIdAsync(id);
                response.Success = result.Success;
                response.Message = result.Message;
            }
            catch (ApiException exception)
            {
                response.Success= false;
                response.Message = exception.Message;   
            }

            return response;
        }

        public async Task<Response<bool>> EditStandardTime(string id, UpdateStandardTimeDto objectBody)
        {
            Response<bool> response = new();
            try
            {
                await GetBearerToken();
                var result = await client.UpdateStandardTimeByIdAsync(id, objectBody);
                response.Success = result.Success;  
                response.Message= result.Message;
            }
            catch (ApiException exception)
            {
                response.Success=false;
                response.Message= exception.Message;
            }

            return response;
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
                return response;
            }
            catch (ApiException aex)
            {
                return new Response<List<GetStandardTimeDto>>() { Message = aex.Message ,Success = false};
            }
            
        }

        public async Task<Response<GetStandardTimeDto>> GetDetails(string id)
        {
            Response<GetStandardTimeDto> response;
            try
            {
                await GetBearerToken();
                var data = await client.GetStandardTimeByIdAsync(id);
                response = new Response<GetStandardTimeDto> ()
                {
                    Data = data.Data,
                    Success = data.Success,
                    Message = data.Message
                };
            }
            catch (ApiException aex)
            {
                return new Response<GetStandardTimeDto> { Success = false , Message = aex.Message};
            }
            return response;
        }
    }
}