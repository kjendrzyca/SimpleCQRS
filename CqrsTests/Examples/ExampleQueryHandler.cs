namespace CqrsTests.Examples
{
    using Infrastructure;

    public class ExampleQueryHandler : IQueryHandler<ExampleQuery, ExampleResult>
    {
        public ExampleResult Handle(ExampleQuery query)
        {
            return new ExampleResult();
        }
    }
}