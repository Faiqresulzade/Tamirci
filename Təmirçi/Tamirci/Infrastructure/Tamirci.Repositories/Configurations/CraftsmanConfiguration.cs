using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tamirci.Entities;

namespace Tamirci.Repositories.Configurations;

public class CraftsmanConfiguration : IEntityTypeConfiguration<Craftsman>
{
    public void Configure(EntityTypeBuilder<Craftsman> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(20);
        builder.Property(x => x.Surname).HasMaxLength(20);
        builder.Property(x => x.PhoneNumber).HasMaxLength(14);

        builder.Property(x => x.CreateDate)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP") 
                  .ValueGeneratedOnAdd(); 

        builder.Property(x => x.UpdateDate)
               .HasDefaultValueSql("CURRENT_TIMESTAMP")
               .ValueGeneratedOnAddOrUpdate();

        builder.HasOne(x => x.RefreshToken)
               .WithOne()
               .HasForeignKey<Craftsman>(x => x.Id);

        builder.Property(x => x.Raiting)
            .HasDefaultValue(5) 
            .IsRequired();

#pragma warning disable CS0618 
        builder.HasCheckConstraint("CK_Raiting_Range", "[Raiting] >= 0 AND [Raiting] <= 5");
#pragma warning restore CS0618 

#pragma warning disable CS0618
        builder.HasCheckConstraint("CK_PhoneNumber_StartWith_994",
            "PhoneNumber LIKE '+994%'");
#pragma warning restore CS0618 

    }
}
