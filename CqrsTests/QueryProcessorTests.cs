namespace CqrsTests
{
    using CqrsTests.Examples;
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
            container.Register<IQueryHandler<QueryExample, QueryResultExample>, QueryHandlerExample>();
            container.Register<IQueryProcessor, QueryProcessor>();
            container.Verify();

            // when
            var queryProcessor = container.GetInstance<QueryProcessor>();
            var exampleResult = queryProcessor.Process<QueryExample, QueryResultExample>(new QueryExample());

            // then
            Assert.That(exampleResult, Is.InstanceOf<QueryResultExample>());
        }
    }
}