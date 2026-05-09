using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> entity)
    {
        entity.Property(x => x.Token).IsRequired();

        entity.Property(t => t.UserId)
            .HasConversion(
                v => v.ToString(),
                v => Guid.Parse(v));
        
        entity.Property(t => t.Id)
            .HasConversion(
                v => v.ToString(),
                v => Guid.Parse(v));

        entity.Property(x => x.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        entity.Property(x => x.IsRevoked)
            .HasDefaultValue(false);

    }
}
