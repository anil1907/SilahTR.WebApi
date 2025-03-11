using AutoMapper;
using SilahTR.Application.Features.Categories.Dtos.Requests;
using SilahTR.Domain.Entities;

namespace SilahTR.Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Entity -> Response mappings
            CreateMap<Category, CreatedCategoryResponse>();
            
            // Request -> Entity mappings
            CreateMap<CreatedCategoryRequest, Category>();

            // // Paginate mapping
            // CreateMap<Paginate<CorporateCustomer>, Paginate<CorporateCustomerResponse>>()
            //     .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
