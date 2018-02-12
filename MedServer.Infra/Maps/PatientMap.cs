using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedServer.Infra.Maps
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Gender);
            builder.Property(x => x.Email).HasMaxLength(60);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Details).HasMaxLength(255);
            builder.Property(x => x.BirthDate);
            builder.Property(x => x.Enabled);
            builder.Ignore(x => x.Schedules);
            builder.Ignore(x => x.Records);
        }
    }
}
