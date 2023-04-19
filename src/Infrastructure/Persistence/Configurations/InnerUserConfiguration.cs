using MediaLink.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaLink.Infrastructure.Persistence.Configurations;
public class InnerUserConfiguration : IEntityTypeConfiguration<InnerUser>
{
    public void Configure(EntityTypeBuilder<InnerUser> builder)
    {
        builder.Property(t => t.UserName)
                .HasMaxLength(200)
                .IsRequired();
    }
}
