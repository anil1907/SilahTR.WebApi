using MediatR;
using AutoMapper;
using SilahTR.Application.Features.Categories.Constants;
using SilahTR.Application.Features.Categories.Dtos.Requests;
using SilahTR.Application.Features.Categories.Dtos.Responses;
using SilahTR.Application.Features.Categories.Rules;
using SilahTR.Domain.Entities;


namespace SilahTR.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>
    {
        public DeletedCategoryRequest Request { get; set; } = default!;

        public class DeleteCorporateCustomerCommandHandler(
            ICategoryRepository  categoryRepository,
            IMapper mapper, CategoryBusinessRules businessRules)
            : IRequestHandler<DeleteCategoryCommand, DeletedCategoryResponse>
        {
            public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
            {

                var category = await categoryRepository.GetAsync(f=>f.Id == command.Request.Id, cancellationToken: cancellationToken);
                
                await businessRules.CategoryNotFound(category);
                
                var deletedCustomer = await categoryRepository.DeleteAsync(category, cancellationToken: cancellationToken);

                var response = mapper.Map<DeletedCategoryResponse>(deletedCustomer);
                response.Message = CategoryMessages.CustomerDeleted;
                
                return response;
            }
        }
    }
}
