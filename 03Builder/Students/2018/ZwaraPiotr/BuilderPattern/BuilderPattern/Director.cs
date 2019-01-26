using BuilderPattern.Abstraction;

namespace BuilderPattern
{
    public class Director
    {
        public TContainer Construct<TContainerBuilder, TContainer>(IContainerBuilder<TContainerBuilder, TContainer> builder)
            where TContainerBuilder : IContainerBuilder<TContainerBuilder, TContainer>
            where TContainer : class
        {
            var logger = new Logger();

            return builder
                .WithSingleton<Logger, ILogger>(logger)
                .WithSingleton<Mapper, IMapper>()
                .WithTransient<UnitOfWork, IUnitOfWork>()
                .Build();
        }
    }
}
