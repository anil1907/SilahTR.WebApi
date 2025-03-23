namespace SilahTR.Application.Features.Categories.Dtos.Responses;

public class DeletedCategoryResponse
{
    public Guid Id { get; set; }
    public string Message { get; set; } = default!;
}