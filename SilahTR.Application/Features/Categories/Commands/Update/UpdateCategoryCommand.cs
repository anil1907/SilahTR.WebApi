using AutoMapper;
using MediatR;
using SilahTR.Application.Features.Categories.Constants;
using SilahTR.Application.Features.Categories.Dtos.Requests;
using SilahTR.Application.Features.Categories.Dtos.Responses;
using SilahTR.Application.Features.Categories.Rules;
using SilahTR.Domain.Entities;

namespace SilahTR.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<UpdatedCategoryResponse>
    {
        public UpdatedCategoryRequest Request { get; set; } = default!;

        public class CreateCorporateCustomerCommandHandler(
            ICategoryRepository  categoryRepository,
            IMapper mapper, CategoryBusinessRules businessRules)
            : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryResponse>
        {
            public async Task<UpdatedCategoryResponse> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
            {
                await businessRules.NameCannotBeDuplicatedWhenInserted(command.Request.Name);

                var corporateCustomer = mapper.Map<Category>(command.Request);
                var createdCustomer = await categoryRepository.UpdateAsync(corporateCustomer, cancellationToken);

                var response = mapper.Map<UpdatedCategoryResponse>(createdCustomer);
                response.Message = CategoryMessages.CustomerCreated;
                
                return response;
            }
        }
    }
}

