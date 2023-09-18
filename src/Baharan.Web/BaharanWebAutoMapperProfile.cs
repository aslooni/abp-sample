using AutoMapper;
using Baharan.Personnels;
using Baharan.Web.Pages.Personnels;
namespace Baharan.Web;
public class BaharanWebAutoMapperProfile : Profile
{
    public BaharanWebAutoMapperProfile()
    {
        CreateMap<CreatePersonnelViewModel, CreateUpdatePersonnelDto>();
        CreateMap<PersonnelDto, EditPersonnelViewModel>();
        CreateMap<EditPersonnelViewModel, CreateUpdatePersonnelDto>();
    }
}
