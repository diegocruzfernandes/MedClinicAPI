using Flunt.Notifications;
using MedServer.Domain.Entities;
using MedServer.Infra.Maps;
using Microsoft.EntityFrameworkCore;

namespace MedServer.Infra.Context
{
    //
    //"Data Source=SIGAMESERVER\SQLEXPRESS;Initial Catalog=MedClinic;User ID=sa;Password=cristal1"

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DON\SQLEXPRESS;Initial Catalog=MedClinic;User ID=sa;Password=admin");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DoctoMap());
            modelBuilder.ApplyConfiguration(new PatientMap());

            modelBuilder.Entity<Schedule>()
                .HasOne(d => d.Doctor)
                .WithMany(s => s.Schedules);

            modelBuilder.Entity<Schedule>()
               .HasOne(p => p.Patient)
               .WithMany(s => s.Schedules);

            modelBuilder.Entity<PatientRecords>()
                .HasOne(p => p.Patient)
                .WithMany(r => r.Records);

            modelBuilder.Ignore<Notification>();

            /*
            modelBuilder.Entity<User>(
                builder =>
                {
                    builder.HasKey(x => x.Id);
                    builder.Property(x => x.Nickname).IsRequired().HasMaxLength(60);
                    builder.Property(x => x.Email).IsRequired().HasMaxLength(60);
                    builder.Property(x => x.Password).IsRequired().HasMaxLength(32);
                    builder.Property(x => x.Permission);
                    builder.Property(x => x.Enabled);
                    builder.Ignore(x => x.Notifications);
                    builder.Ignore(x => x.Invalid);
                    builder.Ignore(x => x.Valid);
                });

            modelBuilder.Entity<Doctor>(
               builder =>
               {
                   builder.HasKey(x => x.Id);
                   builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
                   builder.Property(x => x.Specialty).IsRequired().HasMaxLength(60);
                   builder.Property(x => x.CodeRegister).IsRequired().HasMaxLength(60);
                   builder.Property(x => x.Enabled);
                   builder.Ignore(x => x.Notifications);
                   builder.Ignore(x => x.Invalid);
                   builder.Ignore(x => x.Valid);

               });

            modelBuilder.Entity<Patient>(
              builder =>
              {
                  builder.HasKey(x => x.Id);
                  builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
                  builder.Property(x => x.Gender);
                  builder.Property(x => x.Age);
                  builder.Property(x => x.Enabled);
                  builder.Ignore(x => x.Notifications);
                  builder.Ignore(x => x.Invalid);
                  builder.Ignore(x => x.Valid);

              });
              */
            base.OnModelCreating(modelBuilder);
        }
    }
}