using System.Collections.Generic;
using System.Linq;
using Interfaces.Entities;

namespace Interfaces.Base
{
	public interface IReadOnlyService<T> where T : class
	{
		T GetById(int id);

		T GetByIdAsNoTracking(int id);

		IEnumerable<T> GetAll();

		IQueryable<T> GetAllLightWeight();

		IQueryable<T> GetAllForList(bool includeInactive = false);

		IPagedResult<T> GetAllPagedForList(ISearchFilterDto searchFilterDto);

		IQueryable<T> GetAllForExport(ISearchFilterDto searchFilterDto);

		bool Any();
	}
}
