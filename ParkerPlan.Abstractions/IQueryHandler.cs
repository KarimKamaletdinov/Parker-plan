namespace ParkerPlan.Abstractions
{
    public interface IQueryHandler<T, TResult> where T : Query<TResult>
    {
        TResult Execute(T query);
    }
}