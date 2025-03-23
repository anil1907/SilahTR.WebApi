using MediatR;
using AutoMapper;
using SilahTR.Application.Features.Categories.Dtos.Responses;

namespace SilahTR.Application.Features.Categories.Queries.GetList
{
    public class GetListCategoryQuery : IRequest<Paginate<CategoryResponse>>
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = int.MaxValue;

        public class GetListCategoryQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
            : IRequestHandler<GetListCategoryQuery, Paginate<CategoryResponse>>
        {
            public async Task<Paginate<CategoryResponse>> Handle(GetListCategoryQuery request,
                CancellationToken cancellationToken)
            {
                var categories = await categoryRepository.GetListAsync(
                    index: request.PageIndex,
                    size: request.PageSize,
                    cancellationToken: cancellationToken
                );

                var response = mapper.Map<Paginate<CategoryResponse>>(categories);
                return response;
            }
        }
    }
}