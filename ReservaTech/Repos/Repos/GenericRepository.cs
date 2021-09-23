using System;
using System.Linq;
using Data.Access;
using Entities.Core;
using Interfaces.Repos;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly ApplicationDbContext context;
		protected GenericRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Inserts the object in database and returns the number of rows affected.
		/// </summary>
		public virtual bool Insert(T obj, bool save = true)
		{
			((GenericEntity) (object) obj).CreatedDate = DateTime.UtcNow;
			((GenericEntity) (object) obj).UpdatedDate = Constants.EmptyDate;
			context.Entry(obj).State = EntityState.Added;
			context.Set<T>().Add(obj);
			return save && Save() > 0;
		}

		/// <summary>
		/// Updates the object in database and returns the number of rows affected.
		/// </summary>
		public virtual bool Update(T obj, bool save = true)
		{
			((GenericEntity) (object) obj).UpdatedDate = DateTime.UtcNow;
			context.Entry(obj).State = EntityState.Modified;
			return save && Save() > 0;
		}

		/// <summary>
		/// Deletes the object in database and returns true if there is at least one row affected.
		/// </summary>
		public virtual bool Delete(T obj, bool save = true)
		{
			context.Entry(obj).State = EntityState.Deleted;
			context.Set<T>().Remove(obj);
			return save && Save() > 0;
		}

		public virtual int Save()
		{
			return context.SaveChanges();
		}

		public virtual bool Any()
		{
			return context.Set<T>().Any();
		}

		/// <summary>
		/// Returns the list of all objects in database.
		/// </summary>
		public virtual IQueryable<T> GetAll()
		{
			return context.Set<T>();
		}

		/// <summary>
		/// Returns the list of all objects in database without any include.
		/// </summary>
		public IQueryable<T> GetAllLightWeight()
		{
			return context.Set<T>();
		}

		/// <summary>
		/// Returns the list of all objects in database.
		/// </summary>
		public virtual IQueryable<T> GetAllForList(bool includeInactive = false)
		{
			return context.Set<T>();
		}

		public virtual T GetById(int id)
		{
			return GetAll().FirstOrDefault(obj => ((GenericEntity) (object) obj).Id == id);
		}

		public virtual T GetByIdAsNoTracking(int id)
		{
			return GetAll().AsNoTracking().FirstOrDefault(obj => ((GenericEntity) (object) obj).Id == id);
		}
	}
}
