using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
