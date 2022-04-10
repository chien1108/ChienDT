using LecturerManagement.Server.UI.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagement.Server.UI.Services.StandardTimeServices
{
    public interface IStandardTimeService
    {
        Task<Response<List<GetStandardTimeDto>>> GetAllStandardTime();
        Task<Response<GetStandardTimeDto>> GetDetails(string id);
        Task<Response<bool>> AddStandardTime(AddStandardTimeDto objectBody);
        Task<Response<bool>> EditStandardTime(string id, UpdateStandardTimeDto objectBody);
        Task<Response<bool>> DeleteStandardTime(string id);
       
    }
}