namespace Infrastructure
{
    using SimpleInjector;

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _container;

        public CommandDispatcher(Container container)
        {
            _container = container;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _container.GetInstance<ICommandHandler<TCommand>>();

            commandHandler.Execute(command);
        }
    }
}