using MediatR;
using Microsoft.AspNetCore.Mvc;
using SilahTR.Application.Features.Categories.Dtos.Responses;
using SilahTR.Application.Features.Categories.Queries.GetList;
using SilahTR.WebApi.Infrastructure;

namespace SilahTR.WebApi.Endpoints;

public class Categories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGet("/addresses/cities", GetCities).RequireAuthorization("User");
    }
    
    public async Task<Paginate<CategoryResponse>> GetCities(ISender sender, [AsParameters] GetListCategoryQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}