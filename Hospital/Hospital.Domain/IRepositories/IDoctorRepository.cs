using Hospital.Domain.Entities;

namespace Hospital.Domain.IRepositories
{
	public interface IDoctorRepository : IGenericRepository<Doctor>
	{
		Doctor FindByIdWithPatientsInfo(int id);
	}
}
