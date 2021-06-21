using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contexts
{
    public class MyContexts : DbContext
    {
        public MyContexts(DbContextOptions<MyContexts> options) : base(options)
        {
        }
        //1 project hanya 1 punya 1 MyContexts
        //menghubungkan project dengan db -> di proses oleh DbContext
        //dr DbContext terdiri dr dbset,
        //semakin banyak table, semakin banyak dbsetnya

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Employees> Employees { get; set; } //set nama table sesuai dengan Dbset
        public DbSet<Universities> Universities { get; set; }
        public DbSet<Educations> Educations { get; set; }
        public DbSet<Profilings> Profilings { get; set; }
        public DbSet<Accounts> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relation antara edu & uni
            modelBuilder.Entity<Universities>()
                .HasMany(c => c.Educations)
                .WithOne(e => e.Universities)
                .IsRequired();

            modelBuilder.Entity<Educations>()
                .HasOne(e => e.Universities)
                .WithMany(c => c.Educations)
                .IsRequired();

            //relasi antara edu & profile
            modelBuilder.Entity<Educations>()
                .HasMany(c => c.Profilings)
                .WithOne(e => e.Educations)
                .IsRequired();

            modelBuilder.Entity<Profilings>()
                .HasOne(e => e.Educations)
                .WithMany(c => c.Profilings)
                .IsRequired();

            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.Profilings)
                .WithOne(b => b.Accounts)
                .HasForeignKey<Profilings>(b => b.NIK);

            modelBuilder.Entity<Employees>()
                .HasOne(a => a.Accounts)
                .WithOne(b => b.Employees)
                .HasForeignKey<Accounts>(b => b.NIK);
            
            modelBuilder.Entity<Employees>()
                .Property(e => e.Gender)
                .HasConversion<string>();

            /*modelBuilder.Entity<Rider>()
                .Property(e => e.Mount)
                .HasConversion(v => v.ToString(),
                v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));
            
             modelBuilder.Entity<Rider>()
                .Property(e => e.Mount)
                .HasConversion<string>();*/
        }

        //add migration
        //update-database
        //ketika ada perubahan pada atribut/nama atribut,
        //maka harus dilakukan add migration dan update database
        //

    }
}
