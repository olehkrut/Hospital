using System;
using Hospital.DataAccess;
using Hospital.Domain.IRepositories;
using Hospital.Domain.IUnitOfWork;
using Hospital.Repositories_EF_.Repositories.EF;

namespace Hospital.Repositories_EF_.UnitOfWork
{
	public class UnitOfWorkEF : IUnitOfWork
	{
		private readonly HospitalDbContext _context = new HospitalDbContext();
		private bool _disposed;

		private IDoctorRepository _doctorsRepository;
		private IPatientRepository _patientRepository;

		public IDoctorRepository DoctorRepository
		{
			get { return _doctorsRepository ?? (_doctorsRepository = new DoctorRepository(_context)); }
		}
		public IPatientRepository PatientRepository
		{
			get { return _patientRepository ?? (_patientRepository = new PatientRepository(_context)); }
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected  virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_disposed = true;
		}
	}
}
