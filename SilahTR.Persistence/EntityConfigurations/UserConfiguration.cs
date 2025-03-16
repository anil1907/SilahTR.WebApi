using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilahTR.Domain.Entities;

namespace SilahTR.Persistence.EntityConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(c => c.LastName)
                .HasDefaultValue(0)
                .IsRequired();

            builder.ComplexProperty(c => c.IdentityNumber)
                .IsRequired();
        }
    }
}
