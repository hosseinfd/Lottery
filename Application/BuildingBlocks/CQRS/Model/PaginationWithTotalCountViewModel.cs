namespace Co.Backend.Packages.Application.BuildingBlocks.CQRS.Model;

public abstract class PaginationWithTotalCountViewModel<T>
{
    protected PaginationWithTotalCountViewModel(IList<T> items, int currentPage, int totalPages, int totalCount)
    {
        Items = items;
        Page = new PageWithTotalCount(currentPage, totalPages, items.Count, totalCount);
    }

    public IList<T> Items { get; }
    public PageWithTotalCount Page { get; }

}