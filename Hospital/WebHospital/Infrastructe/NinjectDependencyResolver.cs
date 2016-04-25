using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Hospital.Domain.IRepositories;
using Hospital.Domain.IServices;
using Hospital.Domain.IUnitOfWork;
using Hospital.Repositories_EF_;
using Hospital.Repositories_EF_.Repositories.EF;
using Hospital.Repositories_EF_.UnitOfWork;
using Hospital.Services;
using Ninject;

namespace Hospital.Infrastructe
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private readonly IKernel _kernel;

		public NinjectDependencyResolver(IKernel kernel)
		{
			_kernel = kernel;
			AddBindings();
		}


		public object GetService(Type serviceType)
		{
			return _kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			_kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
			_kernel.Bind<IPatientRepository>().To<PatientRepository>();
			_kernel.Bind<IDoctorRepository>().To<DoctorRepository>();
			_kernel.Bind<IDoctorService>().To<DoctorService>();
			_kernel.Bind<IPatientService>().To<PatientService>();
		}
	}
}