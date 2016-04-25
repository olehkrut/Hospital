﻿using Hospital.Domain.Entities;

namespace Hospital.Domain.IRepositories
{
	public interface 
		IPatientRepository : IGenericRepository<Patient>
	{
		Patient FindByIdWithDoctorInfo(int id);
	}
}
