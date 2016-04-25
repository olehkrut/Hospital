using System.Data.Entity;
using System.Linq;
using Hospital.Domain.Entities;
using Hospital.Domain.IRepositories;

namespace Hospital.Repositories_EF_
{
	public class PatientRepository : EFRepository<Patient>, IPatientRepository
	{
		public PatientRepository(DbContext context) : base(context)
		{
		}

		public Patient FindByIdWithDoctorInfo(int id)
		{
			return DbSet.Include(p => p.Doctor).FirstOrDefault(p => p.Id == id);
		}
	}
}
