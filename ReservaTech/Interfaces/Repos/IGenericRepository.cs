using System.Linq;

namespace Interfaces.Repos
{
	/// <summary>
	/// Interface for Generic Repository basic operations
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IGenericRepository<T>
	{
		bool Insert(T obj, bool save = true);

		bool Update(T obj, bool save = true);

		bool Delete(T obj, bool save = true);

		int Save();
        
        bool Any();
		
        T GetById(int id);

	    T GetByIdAsNoTracking(int id);

        IQueryable<T> GetAll();

	    IQueryable<T> GetAllLightWeight();

	    IQueryable<T> GetAllForList(bool includeInactive = false);
		
	}
}