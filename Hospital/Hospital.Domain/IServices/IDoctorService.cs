using System.Collections.Generic;
using Hospital.Domain.Entities;

namespace Hospital.Domain.IServices
{
	public interface IDoctorService
	{
		List<Doctor> LoadAllDoctors();
		Doctor FindDoctorById(int id);
		void RegisterNewDoctor(Doctor doctor);
		void UpdateDoctor(Doctor doctor);
		void DeleteDoctor(int id);
	}
}
