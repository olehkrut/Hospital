using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebHospital.Migrations;


namespace WebHospital.ConfigurationEF
{
    class HospitalDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public HospitalDbContext() : base("HospitalContext") 
        {
            Database.SetInitializer<HospitalDbContext>(new Configuration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Doctor>(new DoctorEntityConfiguration());
            modelBuilder.Configurations.Add<Patient>(new PatientEntityConfiguration());

            //modelBuilder.Entity<Doctor>().HasMany<Patient>(d => d.Patients)
            //    .WithRequired(p => p.Doctor)
            //    .HasForeignKey<int>(p => p.DoctorId)
            //    .WillCascadeOnDelete(true);
            //modelBuilder.Entity<Patient>().HasRequired<Doctor>(p => p.Doctor)
            //    .WithMany(d => d.Patients)
            //    .HasForeignKey<int>(p => p.DoctorId)
            //    .WillCascadeOnDelete(true);
        }
    }
}
