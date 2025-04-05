using MediatR;
using AutoMapper;
using SilahTR.Application.Features.Categories.Constants;
using SilahTR.Application.Features.Categories.Dtos.Requests;
using SilahTR.Application.Features.Categories.Rules;
using SilahTR.Domain.Entities;
using SilahTR.Infrastructure.Repositories;

namespace SilahTR.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<ResultObject<CreatedCategoryResponse>>
    {
        public CreatedCategoryRequest Request { get; set; } = default!;

        public class CreateCorporateCustomerCommandHandler(
            ICategoryRepository  categoryRepository,
            IMapper mapper, CategoryBusinessRules businessRules)
            : IRequestHandler<CreateCategoryCommand, ResultObject<CreatedCategoryResponse>>
        {
            public async Task<ResultObject<CreatedCategoryResponse>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
            {
                await businessRules.NameCannotBeDuplicatedWhenInserted(command.Request.Name);

                var corporateCustomer = mapper.Map<Category>(command.Request);
                var createdCustomer = await categoryRepository.AddAsync(corporateCustomer, cancellationToken);

                var response = mapper.Map<CreatedCategoryResponse>(createdCustomer);
                response.Message = CategoryMessages.CustomerCreated;
                
                return ResultObject<CreatedCategoryResponse>.Success(response);
            }
        }
    }
}
