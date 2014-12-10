namespace CqrsTests
{
    using CqrsTests.Examples;
    using Infrastructure;
    using NUnit.Framework;
    using SimpleInjector;

    [TestFixture]
    public class SimpleInjectorExploration
    {
        [Test]
        public void Should_correctly_register_dependencies()
        {
            // given
            var container = new Container();
            container.Register<IQuery<QueryResultExample>, QueryExample>();
            container.Verify();

            // when
            var instance = container.GetInstance<IQuery<QueryResultExample>>();

            // then
            Assert.That(instance, Is.TypeOf<QueryExample>());
        }

        [Test]
        public void Should_register_container_to_itself()
        {
            // given
            var container = new Container();

            // when
            var instance = container.GetInstance<Container>();

            // then
            Assert.That(instance, Is.TypeOf<Container>());
        }
    }
}
