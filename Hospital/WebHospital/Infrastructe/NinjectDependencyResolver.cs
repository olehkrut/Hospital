using System.Web.Mvc;
using Hospital.Domain.IRepositories;
using Hospital.Repositories_EF_;
using Hospital.Repositories_EF_.Repositories.EF;
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


		public object GetService(System.Type serviceType)
		{
			return _kernel.TryGet(serviceType);
		}

		public System.Collections.Generic.IEnumerable<object> GetServices(System.Type serviceType)
		{
			return _kernel.GetAll(serviceType);
		}

		private void AddBindings()
		{
			_kernel.Bind<IPatientRepository, PatientRepository>();
			_kernel.Bind<IDoctorRepository, DoctorRepository>();
		}
	}
}