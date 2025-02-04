using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tamirci.Entities;

namespace Tamirci.Repositories.Configurations;

internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.Property(x => x.Token)
                   .HasMaxLength(500)
                   .IsRequired();

        builder.Property(x => x.ExpiryTime)
               .IsRequired();

        builder.HasOne(x => x.Craftsman)
               .WithOne(x => x.RefreshToken)
               .HasForeignKey<RefreshToken>(x => x.CraftsmanId)
               .IsRequired();
    }
}
