namespace SilahTR.Application.Features.Categories.Dtos.Responses;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Order { get; set; } = default!;
}