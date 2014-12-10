namespace CqrsTests
{
    using Infrastructure;
    using NUnit.Framework;
    using SimpleInjector;

    [TestFixture]
    public class QueryProcessorTests
    {
        [Test]
        public void Should_use_correct_handler_to_handle_query()
        {
            // given
            var container = new Container();
            container.Register<IQueryHandler<ExampleQuery, ExampleResult>, ExampleQueryHandler>();
            container.Register<IQueryProcessor, QueryProcessor>();
            container.Verify();

            // when
            var queryProcessor = container.GetInstance<QueryProcessor>();
            var exampleResult = queryProcessor.Process<ExampleQuery, ExampleResult>(new ExampleQuery());

            // then
            Assert.That(exampleResult, Is.TypeOf<ExampleResult>());
        }
    }
}