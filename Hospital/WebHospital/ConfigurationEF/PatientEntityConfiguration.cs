using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace WebHospital.ConfigurationEF
{
    class PatientEntityConfiguration : EntityTypeConfiguration<Patient>
    {
        public PatientEntityConfiguration()
        {
            //Primary Key
            HasKey<int>(p => p.Id);

            //Properties
            ToTable("Patients");
            Property(p => p.FirstName).HasColumnName("First Name");
            Property(p => p.LastName).HasColumnName("Last Name");
            Property(p => p.Disease).HasColumnName("Disease");
            Property(p => p.DoctorId).HasColumnName("DoctorId");

            //Table & Column Mappings
            HasRequired<Doctor>(p => p.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey<int>(p => p.DoctorId)
                .WillCascadeOnDelete(true);
        }
        
    }
}
