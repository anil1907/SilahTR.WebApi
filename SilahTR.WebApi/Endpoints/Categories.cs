using MediatR;
using SilahTR.Application.Features.Categories.Commands.Create;
using SilahTR.Application.Features.Categories.Commands.Update;
using SilahTR.Application.Features.Categories.Dtos.Responses;
using SilahTR.Application.Features.Categories.Queries.GetList;
using SilahTR.Infrastructure.Repositories;
using SilahTR.WebApi.Infrastructure;

namespace SilahTR.WebApi.Endpoints;

public class Categories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGet("/category", GetCategories);
        
        app.MapPost("/category", CreateCategory).RequireAuthorization();
        
        app.MapPut("/category", UpdateCategory).RequireAuthorization();

    }
    
    private async Task<Paginate<CategoryResponse>> GetCategories(ISender sender, [AsParameters] GetListCategoryQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
    
    private async Task<ResultObject<CreatedCategoryResponse>> CreateCategory(ISender sender, [AsParameters] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
    
    private async Task<ResultObject<UpdatedCategoryResponse>> UpdateCategory(ISender sender, [AsParameters] UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}