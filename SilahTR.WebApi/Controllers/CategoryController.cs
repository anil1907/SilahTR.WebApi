using Microsoft.AspNetCore.Mvc;
using SilahTR.Application.Features.Categories.Commands.Create;

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
    }
}