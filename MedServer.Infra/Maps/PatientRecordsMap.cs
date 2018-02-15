using MedServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedServer.Infra.Maps
{
    public class PatientRecordsMap : IEntityTypeConfiguration<PatientRecords>
    {
        public void Configure(EntityTypeBuilder<PatientRecords> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
