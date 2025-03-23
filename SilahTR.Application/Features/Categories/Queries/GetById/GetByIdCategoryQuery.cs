using MediatR;
using AutoMapper;
using SilahTR.Application.Features.Categories.Dtos.Responses;
using SilahTR.Application.Features.Categories.Rules;

namespace SilahTR.Application.Features.Categories.Queries.GetById
{
    public class GetByIdCategoryQuery : IRequest<CategoryResponse>
    {
        public Guid Id { get; set; }
        
        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules  _categoryBusinessRules;

            public GetByIdCategoryQueryHandler(
                ICategoryRepository categoryRepository,
                IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<CategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryShouldExistWhenRequested(request.Id);

                var customer = await _categoryRepository.GetAsync(c => c.Id == request.Id);
                return _mapper.Map<CategoryResponse>(customer);
            }
        }
    }
}

