using System;
using Hospital.Domain.IRepositories;

namespace Hospital.Domain.IUnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IDoctorRepository DoctorRepository { get; }
		IPatientRepository PatientRepository { get; }
		void Save();
	}
}
