using LecturerManagement.Server.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.Server.Services.StandardTimeServices
{
    public interface IStandardTimeService
    {
        Task<Response<List<GetStandardTimeDto>>> GetAllStandardTime();
        Task<Response<GetAccountDto>> GetDetails(string id);
        Task<Response<bool>> AddStandardTime(AddStandardTimeDto standardTime);
        Task<Response<bool>> EditStandardTime(string id, UpdateAdvancedLearningDto updateAdvancedLearning);
        Task<Response<bool>> DeleteStandardTime(string id);
       
    }
}