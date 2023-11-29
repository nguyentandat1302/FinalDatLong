using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinalDatLong.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<ListOfMedications> ListOfMedications { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Treatment> Treatment { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Specialization)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Feedback1)
                .IsUnicode(false);

            modelBuilder.Entity<ListOfMedications>()
                .Property(e => e.Medicine)
                .IsUnicode(false);

            modelBuilder.Entity<ListOfMedications>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
