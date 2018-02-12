using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Infra.Maps
{
    public class DoctoMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Specialty).IsRequired().HasMaxLength(60);
            builder.Property(x => x.CodeRegister).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Enabled);
            builder.Ignore(x => x.Schedules);
        }
    }
}
