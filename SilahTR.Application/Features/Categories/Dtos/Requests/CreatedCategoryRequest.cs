namespace SilahTR.Application.Features.Categories.Dtos.Requests;

public class CreatedCategoryRequest
{
    public string Name { get; set; } = default!;
    public int DisplayOrder { get; set; } = default!;
    public bool IsActive { get; set; } = default!;
}