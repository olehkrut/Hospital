using System.Data.Entity;
using System.Linq;
using Hospital.Domain.Entities;
using Hospital.Domain.IRepositories;

namespace Hospital.Repositories_EF_.Repositories.EF
{
	public class DoctorRepository : EFRepository<Doctor>, IDoctorRepository
	{
		public DoctorRepository(DbContext context) : base(context)
		{
		}

		public Doctor FindByIdWithPatientsInfo(int id)
		{
			return DbSet.Include(d => d.Patients).FirstOrDefault(d => d.Id == id);
		}
	}
}
