using System.Data.Entity;
using Hospital.Domain.Entities;

namespace Hospital.DataAccess.Seed
{
	internal sealed class Configuration : DropCreateDatabaseAlways<HospitalDbContext>
	{
		public Configuration()
		{
			//AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(HospitalDbContext context)
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
