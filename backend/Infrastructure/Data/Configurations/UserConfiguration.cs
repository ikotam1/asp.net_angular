using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        // Required fields
        entity.Property(x => x.Email).IsRequired();
        entity.Property(x => x.Name).IsRequired();
        entity.Property(x => x.PasswordHashed).IsRequired();

        // Unique index on Email
        entity.HasIndex(x => x.Email).IsUnique();

        // Configure Id as string in the database
        entity.Property(u => u.Id)
            .HasConversion(
                v => v.ToString(),
                v => Guid.Parse(v));
    }
}