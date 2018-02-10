using MedServer.Domain.Entities;
using MedServer.Infra.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            //  modelBuilder.ApplyConfiguration(new UserMap());

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
        }
    }
}
