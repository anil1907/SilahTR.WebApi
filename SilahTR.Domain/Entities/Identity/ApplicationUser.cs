using Microsoft.AspNetCore.Identity;
using SilahTR.Domain.Common;

namespace SilahTR.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<Guid>, IEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    public ApplicationUser()
    {
        CreatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }
} 