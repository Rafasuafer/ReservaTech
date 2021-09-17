using System.Collections.Generic;

namespace Interfaces.Base
{
	public interface IPagedResult<T>
	{
		int CurrentPageIndex { get; set; }
		int CurrentPageItemCount { get; set; }
		int TotalPageCount { get; set; }
		int TotalItemCount { get; set; }
	    IEnumerable<T> Page  { get; set; }
	}
}