using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedServer.Infra.Maps
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Initial).IsRequired();
            builder.Property(x => x.Finish);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.DateReg).IsRequired();
            //builder.HasOne(d => d.Doctor).WithMany(s => s.Schedules);
            //builder.HasOne(p => p.Patient).WithMany(s => s.Schedules);
           
        }
    }
}
