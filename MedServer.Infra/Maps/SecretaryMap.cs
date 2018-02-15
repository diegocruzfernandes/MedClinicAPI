using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedServer.Infra.Maps
{
    public class SecretaryMap : IEntityTypeConfiguration<Secretary>
    {
        public void Configure(EntityTypeBuilder<Secretary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Document).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Enabled);
        }
    }
}
