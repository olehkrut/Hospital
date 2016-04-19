using Hospital.Domain.IUnitOfWork;

namespace Hospital.Repositories_EF_.UnitOfWork
{
	class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public IUnitOfWork GetUnitOfWork()
		{
			return new UnitOfWorkEF();
		}
	}
}
