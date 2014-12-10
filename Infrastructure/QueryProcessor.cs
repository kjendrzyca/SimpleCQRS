namespace Infrastructure
{
    using SimpleInjector;

    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly Container _container;

        public QueryProcessor(Container container)
        {
            _container = container;
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var queryHandler = _container.GetInstance<IQueryHandler<TQuery, TResult>>();

            var result = queryHandler.Handle(query);

            return result;
        }
    }
}