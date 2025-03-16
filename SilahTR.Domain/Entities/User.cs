using Microsoft.AspNetCore.Identity;
using SilahTR.Domain.ValueObjects;

namespace SilahTR.Domain.Entities
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required IdentificationNumber IdentityNumber { get; set; }
        public required DateTime DateOfBirth { get; set; }
    }
}
