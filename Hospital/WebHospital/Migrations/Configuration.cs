namespace WebHospital.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    

    internal sealed class Configuration : DropCreateDatabaseAlways<WebHospital.ConfigurationEF.HospitalDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebHospital.ConfigurationEF.HospitalDbContext context)
        {
             // This method will be called after migrating to the latest version.

            var doc1 = context.Doctors.Add(new Doctor { FirstName = "Andrew", LastName = "Lols", Qualification = "B" });
            var doc2 = context.Doctors.Add(new Doctor { FirstName = "Gregory", LastName = "House", Qualification = "A" });
            context.Patients.Add(new Patient { FirstName = "Barack", LastName = "Obama", Disease = "Stomachache", Doctor = doc2 });
            context.Patients.Add(new Patient { FirstName = "Jack", LastName = "Sparrow", Disease = "Cancer", Doctor = doc1 });
            context.SaveChanges();

        }
    }
}
