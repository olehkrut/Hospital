using System.Collections.Generic;
using System.Linq;
using Hospital.Domain.Entities;
using Hospital.Domain.IServices;
using Hospital.Domain.IUnitOfWork;

namespace Hospital.Services
{
	public class PatientService : IPatientService
	{
		private readonly IUnitOfWorkFactory _factory;

		public PatientService(IUnitOfWorkFactory factory)
		{
			_factory = factory;
		}

		public List<Patient> LoadAllPatients()
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				return uow.PatientRepository.GetAll().ToList();
			}
		}

		public Patient FindPatientById(int id)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				return uow.PatientRepository.FindById(id);
			}
		}

		public void RegisterNewPatient(Patient patient)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				uow.PatientRepository.Add(patient);
			}
		}

		public void UpdatePatient(Patient patient)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				uow.PatientRepository.Update(patient);
			}
		}

		public void DeletePatient(int id)
		{
			using (IUnitOfWork uow = _factory.GetUnitOfWork())
			{
				uow.PatientRepository.Delete(id);
			}
		}
	}
}
