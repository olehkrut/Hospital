using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Hospital.Domain.IRepositories;

namespace Hospital.Repositories_EF_
{
	public class EFRepository<T> : IGenericRepository<T> where T: class
	{
		public EFRepository(DbContext dbContext)
		{
			if (dbContext == null)
			{
				throw new ArgumentException("dbContext");
			}

			DbContext = dbContext;
			DbSet = dbContext.Set<T>();
			dbContext.SaveChanges();
		}
		protected DbContext DbContext { get; set; }
		protected DbSet<T> DbSet { get; set; }

		public virtual IQueryable<T> GetAll()
		{
			return DbSet;
		}

		public virtual T FindById(int id)
		{
			return DbSet.Find(id);
		}

		public virtual void Add(T entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			if (dbEntityEntry.State != EntityState.Detached)
			{
				dbEntityEntry.State = EntityState.Added;
			}
			else
			{
				DbSet.Add(entity);
			}
		}

		public virtual void Add(IEnumerable<T> entities)
		{
			foreach(var entity in entities)
			{
				Add(entity);
			}
		}

		public void Update(T entity)
		{
			//DbSet.AddOrUpdate(entity);
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			if (dbEntityEntry.State == EntityState.Detached)
			{
				DbSet.Attach(entity);
			}
			dbEntityEntry.State = EntityState.Modified;
		}

		public void Delete(T entity)
		{
			DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
			if (dbEntityEntry.State != EntityState.Deleted)
			{
				dbEntityEntry.State = EntityState.Deleted;
			}
			else
			{
				DbSet.Attach(entity);
				DbSet.Remove(entity);
			}
		}

		public void Delete(int id)
		{
			var entity = FindById(id);
			if (entity == null)
			{
				return;
			}
			Delete(entity);
		}

		protected bool Exists(int id)
		{
			return FindById(id) != null;
		}
	}
}
