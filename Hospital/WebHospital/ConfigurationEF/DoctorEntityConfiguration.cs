using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace WebHospital.ConfigurationEF
{
    class DoctorEntityConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorEntityConfiguration()
        {
            //Primary Key
            HasKey<int>(d => d.Id);

            //Properties
            ToTable("Doctors");
            Property(d => d.Id).HasColumnName("Id");
            Property(d => d.FirstName).HasColumnName("First Name");
            Property(d => d.LastName).HasColumnName("Last Name");
            Property(d => d.Qualification).HasColumnName("Qualification");

            //Table & Column Mappings
            HasMany<Patient>(d => d.Patients)
                .WithRequired(p => p.Doctor)
                .HasForeignKey<int>(p => p.DoctorId)
                .WillCascadeOnDelete(true);
        }
        
    }
}
