namespace CqrsTests.Examples
{
    using Infrastructure;

    public class QueryHandlerExample : IQueryHandler<QueryExample, QueryResultExample>
    {
        public QueryResultExample Handle(QueryExample query)
        {
            return new QueryResultExample();
        }
    }
}