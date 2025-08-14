using AutoMapper;
using RealEstate.Core.DTO;
using RealEstate.Core.Entities;

namespace RealEstate.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Property, PropertyDto>().ReverseMap();
        }
    }
}
