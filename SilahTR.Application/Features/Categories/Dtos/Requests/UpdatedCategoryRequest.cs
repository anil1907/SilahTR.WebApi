namespace SilahTR.Application.Features.Categories.Dtos.Requests
{
    public class UpdatedCategoryRequest
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int DisplayOrder { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
    }
}

