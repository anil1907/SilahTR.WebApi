namespace SilahTR.Application.Features.Categories.Dtos.Responses
{
    public class UpdatedCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
}
