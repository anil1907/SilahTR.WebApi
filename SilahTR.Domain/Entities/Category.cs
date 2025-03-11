namespace SilahTR.Domain.Entities;

public class Category: Entity<Guid>
{
    public required string Name { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
}