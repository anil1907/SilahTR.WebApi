using Microsoft.AspNetCore.Mvc;
using SilahTR.Application.Features.Categories.Commands.Create;
using SilahTR.Application.Features.Categories.Commands.Delete;
using SilahTR.Application.Features.Categories.Commands.Update;
using SilahTR.Application.Features.Categories.Queries.GetById;
using SilahTR.Application.Features.Categories.Queries.GetList;

namespace SilahTR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand
            createCategoryCommand)
        {
            var result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand
            updateCategoryCommand)
        {
            var result = await Mediator.Send(updateCategoryCommand);
            return Created("", result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand
            deleteCategoryCommand)
        {
            var result = await Mediator.Send(deleteCategoryCommand);
            return Created("", result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetByIdCategoryQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCategoryQuery getListCorporateCustomerQuery)
        {
            var result = await Mediator.Send(getListCorporateCustomerQuery);
            return Ok(result);
        }
    }
}