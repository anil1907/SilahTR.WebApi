namespace SilahTR.Domain.Common;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime? LastModifiedDate { get; set; }
    bool IsDeleted { get; set; }
    DateTime? DeletedDate { get; set; }
} 