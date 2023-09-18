using AutoMapper;
using Baharan.Experiences;
using Baharan.Personnels;

namespace Baharan;

public class BaharanApplicationAutoMapperProfile : Profile
{
    public BaharanApplicationAutoMapperProfile()
    {
        CreateMap<Personnel, PersonnelDto>();
        CreateMap<CreateUpdatePersonnelDto, Personnel>();

        CreateMap<Experience, ExperienceDto>();
        CreateMap<CreateUpdateExperienceDto, Experience>();

    }
}
