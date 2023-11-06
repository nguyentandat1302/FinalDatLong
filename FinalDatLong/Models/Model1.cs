using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinalDatLong.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model0")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Partient> Partients { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<ListOfMedication> ListOfMedications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.IDAdmin)
                .IsFixedLength();

            modelBuilder.Entity<Doctor>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.IDDoctor)
                .IsFixedLength();

            modelBuilder.Entity<Doctor>()
                .Property(e => e.IDAdmin)
                .IsFixedLength();

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Doctor)
                .HasForeignKey(e => e.IDPartient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partient>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Partient>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Partient>()
                .Property(e => e.IDPartient)
                .IsFixedLength();

            modelBuilder.Entity<Partient>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Partient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partient>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Partient)
                .HasForeignKey(e => e.IDDoctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partient>()
                .HasOptional(e => e.Feedback)
                .WithRequired(e => e.Partient);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.IDTreatment)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .Property(e => e.IDDoctor)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .Property(e => e.IDPartient)
                .IsFixedLength();

            modelBuilder.Entity<Treatment>()
                .HasOptional(e => e.ListOfMedication)
                .WithRequired(e => e.Treatment);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.IDDoctor)
                .IsFixedLength();

            modelBuilder.Entity<Appointment>()
                .Property(e => e.IDPartient)
                .IsFixedLength();

            modelBuilder.Entity<Booking>()
                .Property(e => e.IDPartient)
                .IsFixedLength();

            modelBuilder.Entity<Booking>()
                .Property(e => e.IDDoctor)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.IDPartient)
                .IsFixedLength();

            modelBuilder.Entity<ListOfMedication>()
                .Property(e => e.IDTreatment)
                .IsFixedLength();
        }
    }
}
