using AutoMapper;
using LecturerManagement.Server.UI.Services.Base;

namespace LecturerManagement.Server.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<GetStandardTimeDto, UpdateStandardTimeDto>().ReverseMap();
        }
    }
}