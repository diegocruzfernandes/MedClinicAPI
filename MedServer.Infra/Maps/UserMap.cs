using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedServer.Infra.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nickname).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Permission);
            builder.Property(x => x.Enabled);           
        }
    }
}
