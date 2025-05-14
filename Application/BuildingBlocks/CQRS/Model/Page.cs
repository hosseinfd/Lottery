namespace Co.Backend.Packages.Application.BuildingBlocks.CQRS.Model;

public class Page
{
    public Page(int current, int total, int count)
    {
        Current = current;
        Total = total;
        Count = count;
    }

    public int Current { get; }

    public int Total { get; }

    public int Count { get; }

    public int? Next => Current == Total ? null : Current + 1;
}