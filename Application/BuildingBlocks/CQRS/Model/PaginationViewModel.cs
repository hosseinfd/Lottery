using System.Collections.Generic;

namespace Co.Backend.Packages.Application.BuildingBlocks.CQRS.Model;

public abstract class PaginationViewModel<T>
{
    protected PaginationViewModel(IList<T> items, int currentPage, int totalPages)
    {
        Items = items;
        Page = new Page(currentPage, totalPages, items.Count);
    }

    public IList<T> Items { get; }
    public Page Page { get; }

}