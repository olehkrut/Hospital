using System.Data.Entity;
using Hospital.Domain.Entities;
using Hospital.Domain.IRepositories;

namespace Hospital.Repositories_EF_.Repositories.EF
{
	public class DoctorRepository : EFRepository<Doctor>, IDoctorRepository
	{
		public DoctorRepository(DbContext context) : base(context)
		{
		}
	}
}
