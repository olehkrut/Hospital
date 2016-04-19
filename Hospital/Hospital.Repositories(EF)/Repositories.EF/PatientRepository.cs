using System.Data.Entity;
using Hospital.Domain.Entities;
using Hospital.Domain.IRepositories;

namespace Hospital.Repositories_EF_
{
	public class PatientRepository : EFRepository<Patient>, IPatientRepository
	{
		public PatientRepository(DbContext context) : base(context)
		{
		}
	}
}
