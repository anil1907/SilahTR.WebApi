public class CreatedCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public string Message { get; set; } = default!;
}