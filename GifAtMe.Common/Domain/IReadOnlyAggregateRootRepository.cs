namespace GifAtMe.Common.Domain
{
    /// <summary>
    /// Specifies methods available to retrieve
    /// read-only objects.
    /// </summary>
    /// <typeparam name="AggregateType"></typeparam>
    /// <typeparam name="IdType"></typeparam>
    public interface IReadOnlyAggregateRootRepository<AggregateType, IdType> where AggregateType : IAggregateRoot
    {
        AggregateType FindById(IdType id);
    }
}