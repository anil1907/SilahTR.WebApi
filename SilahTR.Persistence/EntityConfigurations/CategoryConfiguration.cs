using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilahTR.Domain.Entities;
using SilahTR.Persistence.Contexts;

namespace SilahTR.Persistence.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category).Pluralize().Underscore(), ApplicationDbContext.DefaultSchema);

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
