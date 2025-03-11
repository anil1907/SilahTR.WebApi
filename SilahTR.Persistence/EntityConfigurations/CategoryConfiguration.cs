using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilahTR.Domain.Entities;

namespace SilahTR.Persistence.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(c => c.DisplayOrder)
                .HasDefaultValue(0)
                .IsRequired();
            
            builder.Property(c => c.IsActive)
                .IsRequired();
        }
    }
}
