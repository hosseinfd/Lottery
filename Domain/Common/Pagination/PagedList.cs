﻿namespace Domain.Common.Pagination;

public class PagedList<T>
{
    public List<T> Items { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    public PagedList(List<T> items, int totalCount, int page, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }

    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}