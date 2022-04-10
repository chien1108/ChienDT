using AutoMapper;
using LecturerManagement.Server.Services.Base;

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