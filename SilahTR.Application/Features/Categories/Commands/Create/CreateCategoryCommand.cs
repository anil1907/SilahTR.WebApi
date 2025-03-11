using MediatR;
using AutoMapper;
using SilahTR.Application.Features.Categories.Constants;
using SilahTR.Application.Features.Categories.Dtos.Requests;
using SilahTR.Application.Features.Categories.Rules;
using SilahTR.Domain.Entities;

namespace SilahTR.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>
    {
        public CreatedCategoryRequest Request { get; set; } = default!;

        public class CreateCorporateCustomerCommandHandler(
            ICategoryRepository  categoryRepository,
            IMapper mapper, CategoryBusinessRules businessRules)
            : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
        {
            public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
            {
                await businessRules.NameCannotBeDuplicatedWhenInserted(command.Request.Name);

                var corporateCustomer = mapper.Map<Category>(command.Request);
                var createdCustomer = await categoryRepository.AddAsync(corporateCustomer);

                var response = mapper.Map<CreatedCategoryResponse>(createdCustomer);
                response.Message = CategoryMessages.CustomerCreated;
                
                return response;
            }
        }
    }
}
