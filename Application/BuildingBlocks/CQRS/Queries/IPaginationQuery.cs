namespace Application.BuildingBlocks.CQRS.Queries;

public interface IPaginationQuery<out T> : IQuery<T>
{
    // public IFilter Filter { get; set; }
}