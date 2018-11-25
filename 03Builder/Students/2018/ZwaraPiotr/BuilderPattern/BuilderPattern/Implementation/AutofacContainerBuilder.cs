using Autofac;
using Autofac.Core;

using BuilderPattern.Abstraction;

namespace BuilderPattern.Implementation
{
    public class AutofacContainerBuilder : IContainerBuilder<AutofacContainerBuilder, Container>
    {
        private readonly ContainerBuilder autoFacBuilder = new ContainerBuilder();

        public AutofacContainerBuilder WithSingleton<TImplementation, TAbstraction>(TImplementation instance)
            where TImplementation : class, TAbstraction
            where TAbstraction : class
        {
            this.autoFacBuilder
                .RegisterInstance<TAbstraction>(instance)
                .SingleInstance();
            return this;
        }

        public AutofacContainerBuilder WithSingleton<TImplementation, TAbstraction>()
            where TImplementation : class, TAbstraction
            where TAbstraction : class
        {
            this.autoFacBuilder
                .RegisterType<TImplementation>().As<TAbstraction>()
                .InstancePerLifetimeScope();
            return this;
        }

        public AutofacContainerBuilder WithTransient<TImplementation, TAbstraction>()
            where TImplementation : class, TAbstraction
            where TAbstraction : class
        {
            this.autoFacBuilder
                .RegisterType<TImplementation>().As<TAbstraction>()
                .InstancePerDependency();
            return this;
        }

        public Container Build()
        {
            return this.autoFacBuilder.Build() as Container;
        }

        public static implicit operator Container(AutofacContainerBuilder builder)
        {
            return builder.Build();
        }
    }
}
