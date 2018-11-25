namespace BuilderPattern.Abstraction
{
    public interface IContainerBuilder<TContainerBuilder, TContainer>
        where TContainerBuilder : IContainerBuilder<TContainerBuilder, TContainer>
        where TContainer : class
    {
        TContainerBuilder WithSingleton<TImplementation, TAbstraction>(TImplementation instance)
            where TImplementation : class, TAbstraction
            where TAbstraction : class;

        TContainerBuilder WithSingleton<TImplementation, TAbstraction>()
            where TImplementation : class, TAbstraction
            where TAbstraction : class;

        TContainerBuilder WithTransient<TImplementation, TAbstraction>()
            where TImplementation : class, TAbstraction
            where TAbstraction : class;

        TContainer Build();
    }
}
