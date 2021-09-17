namespace Interfaces.Entities
{
    public interface ISearchFilterDto
    {
        int? Page { get; set; }
        int? PageSize { get;set; }
        string SortBy { get; set; }
        bool SortAsc { get; set; }
        bool IncludeInactive { get; set; }
    }
}