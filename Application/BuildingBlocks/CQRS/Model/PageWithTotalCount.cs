namespace Co.Backend.Packages.Application.BuildingBlocks.CQRS.Model;

public class PageWithTotalCount
{
    public PageWithTotalCount(int current, int total, int count, int items)
    {
        Current = current;
        Total = total;
        Count = count;
        Items = items;
    }

    public int Current { get; }

    public int Total { get; }

    public int Count { get; }

    public int Items { get; }

    public int? Next => Current == Total ? null : Current + 1;
}