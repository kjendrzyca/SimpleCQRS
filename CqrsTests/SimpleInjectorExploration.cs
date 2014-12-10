namespace CqrsTests
{
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
            container.Register<IQuery<ExampleResult>, ExampleQuery>();
            container.Verify();

            // when
            var instance = container.GetInstance<IQuery<ExampleResult>>();

            // then
            Assert.That(instance, Is.TypeOf<ExampleQuery>());
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
