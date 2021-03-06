﻿using Flunt.Notifications;
using MedServer.Domain.Entities;
using MedServer.Domain.Shared;
using MedServer.Infra.Maps;
using Microsoft.EntityFrameworkCore;

namespace MedServer.Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }        
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TypeConsult> TypesConsult { get; set; }  
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {             
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DoctoMap());
            modelBuilder.ApplyConfiguration(new PatientMap());
            modelBuilder.ApplyConfiguration(new SecretaryMap());
            modelBuilder.ApplyConfiguration(new ScheduleMap());
            modelBuilder.ApplyConfiguration(new TypeConsultMap());

            modelBuilder.Entity<PatientRecords>()
                .HasOne(p => p.Patient)
                .WithMany(r => r.Records);  
         
            modelBuilder.Ignore<Notification>();
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConfigsAppSettings.SQLConnectionString);
        }
    }
}