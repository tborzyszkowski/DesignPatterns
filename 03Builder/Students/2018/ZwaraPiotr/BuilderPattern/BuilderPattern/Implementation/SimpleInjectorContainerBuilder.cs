using SimpleInjector;

using BuilderPattern.Abstraction;

namespace BuilderPattern.Implementation
{
    public class SimpleInjectorContainerBuilder : IContainerBuilder<SimpleInjectorContainerBuilder, Container>
    {
        private readonly Container simpleInjectorContainer = new Container();

        public SimpleInjectorContainerBuilder WithSingleton<TImplementation, TAbstraction>(TImplementation instance)
            where TImplementation : class, TAbstraction
            where TAbstraction : class
        {
            this.simpleInjectorContainer.Register<TAbstraction>(() => instance);
            return this;
        }

        public SimpleInjectorContainerBuilder WithSingleton<TImplementation, TAbstraction>()
            where TImplementation : class, TAbstraction
            where TAbstraction : class
        {
            this.simpleInjectorContainer.Register<TAbstraction, TImplementation>(Lifestyle.Singleton);
            return this;
        }

        public SimpleInjectorContainerBuilder WithTransient<TImplementation, TAbstraction>()
            where TImplementation : class, TAbstraction
            where TAbstraction : class
        {
            this.simpleInjectorContainer.Register<TAbstraction, TImplementation>(Lifestyle.Transient);
            return this;
        }

        public Container Build()
        {
            return this.simpleInjectorContainer;
        }

        public static implicit operator Container(SimpleInjectorContainerBuilder builder)
        {
            return builder.Build();
        }
    }
}
