using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedServer.Infra.Maps
{
    public class TypeConsultMap : IEntityTypeConfiguration<TypeConsult>
    {
        public void Configure(EntityTypeBuilder<TypeConsult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Enabled);
            builder.Ignore(x => x.Schedules);      
        }
    }
}
