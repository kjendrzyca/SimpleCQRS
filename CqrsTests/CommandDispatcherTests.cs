namespace CqrsTests
{
    using System;
    using CqrsTests.Examples;
    using Infrastructure;
    using NUnit.Framework;
    using SimpleInjector;

    [TestFixture]
    public class CommandDispatcherTests
    {
        [Test]
        public void Should_execute_command_if_handler_exists()
        {
            // given
            var container = new Container();
            container.Register<ICommandDispatcher, CommandDispatcher>();
            container.Register<ICommandHandler<ExampleCommand>, ExampleCommandHandler>();
            container.Verify();

            // when -> then
            Assert.DoesNotThrow(() =>
            {
                var commandDispatcher = container.GetInstance<ICommandDispatcher>();
                commandDispatcher.Execute(new ExampleCommand());
            });
        }

        [Test]
        public void Should_not_execute_if_handler_does_not_exist()
        {
            // given
            var container = new Container();
            container.Register<ICommandDispatcher, CommandDispatcher>();
            container.Verify();

            // when -> then
            Assert.Throws<ActivationException>(() =>
            {
                var commandDispatcher = container.GetInstance<ICommandDispatcher>();
                commandDispatcher.Execute(new ExampleCommand());
            });
        }
    }
}