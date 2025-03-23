using AutoMapper;
using SilahTR.Application.Features.Categories.Dtos.Requests;
using SilahTR.Application.Features.Categories.Dtos.Responses;
using SilahTR.Domain.Entities;

namespace SilahTR.Application.Features.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Entity -> Response mappings
            CreateMap<Category, CategoryResponse>();
            CreateMap<Category, CreatedCategoryResponse>();
            CreateMap<Category, UpdatedCategoryRequest>();
            CreateMap<Category, DeletedCategoryRequest>();
            
            // Request -> Entity mappings
            CreateMap<CreatedCategoryRequest, Category>();
            CreateMap<UpdatedCategoryRequest, Category>();
            CreateMap<DeletedCategoryRequest, Category>();

            // // Paginate mapping
            CreateMap<Paginate<Category>, Paginate<CategoryResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
