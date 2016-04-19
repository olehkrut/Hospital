using System.Collections.Generic;
using Hospital.Domain.Entities;

namespace Hospital.Domain.IServices
{
	public interface IPatientService
	{
		List<IPatientService> LoadAllPatients();
		Patient FindPatientById(int id);
		void RegisterNewPatient(Patient patient);
		void UpdatePatient(Patient patient);
		void DeletePatient(int id);
	}
}
