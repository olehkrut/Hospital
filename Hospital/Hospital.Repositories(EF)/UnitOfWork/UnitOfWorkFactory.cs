using Hospital.Domain.IUnitOfWork;

namespace Hospital.Repositories_EF_.UnitOfWork
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public IUnitOfWork GetUnitOfWork()
		{
			return new UnitOfWorkEF();
		}
	}
}
