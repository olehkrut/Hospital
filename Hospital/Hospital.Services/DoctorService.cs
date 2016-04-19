using System.Linq;
using Hospital.Domain.IServices;
using Hospital.Domain.IUnitOfWork;

namespace Hospital.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly IUnitOfWorkFactory _factory;

		public DoctorService(IUnitOfWorkFactory factory)
		{
			_factory = factory;
		}

		public System.Collections.Generic.List<Domain.Entities.Doctor> LoadAllDoctors()
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				return uow.DoctorRepository.GetAll().ToList();
			}
		}

		public Domain.Entities.Doctor FindDoctorById(int id)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				return uow.DoctorRepository.FindById(id);
			}
		}

		public void RegisterNewDoctor(Domain.Entities.Doctor doctor)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				uow.DoctorRepository.Add(doctor);
			}
		}

		public void UpdateDoctor(Domain.Entities.Doctor doctor)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				uow.DoctorRepository.Update(doctor);
			}
		}

		public void DeleteDoctor(int id)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				uow.DoctorRepository.Delete(id);
			}
		}
	}
}
