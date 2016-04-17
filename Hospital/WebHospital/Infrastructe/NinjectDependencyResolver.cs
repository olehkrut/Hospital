using System.Web.Mvc;
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
			
		}
	}
}