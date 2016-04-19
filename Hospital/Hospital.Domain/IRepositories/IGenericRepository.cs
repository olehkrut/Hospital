using System.Collections.Generic;
using System.Linq;

namespace Hospital.Domain.IRepositories
{
	public interface IGenericRepository<T> where T: class
	{
		IQueryable<T> GetAll();
		T FindById(int id);
		void Add(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
