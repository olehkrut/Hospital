namespace Hospital.Domain.IUnitOfWork
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork GetUnitOfWork();
	}
}
