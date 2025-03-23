using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilahTR.Domain.Entities;
using SilahTR.Domain.Entities.Identity;

namespace SilahTR.Persistence.EntityConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(c => c.FirstName)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(c => c.LastName)
                .HasDefaultValue(0)
                .IsRequired();

            // builder.ComplexProperty(c => c.IdentityNumber)
            //     .IsRequired();
        }
    }
}
