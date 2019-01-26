using Autofac;
using NUnit.Framework;

using AutofacContainer = Autofac.Core.Container;
using SimpleInjectorContainer = SimpleInjector.Container;

using BuilderPattern.Implementation;

namespace BuilderPattern.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AutofacContainerBuilderTest()
        {
            var director = new Director();
            AutofacContainer container = director.Construct(new AutofacContainerBuilder());

            Assert.IsInstanceOf<Logger>(container.Resolve<ILogger>());
            Assert.IsInstanceOf<Mapper>(container.Resolve<IMapper>());
            Assert.IsInstanceOf<UnitOfWork>(container.Resolve<IUnitOfWork>());

            Assert.AreSame(container.Resolve<ILogger>(), container.Resolve<ILogger>());
            Assert.AreSame(container.Resolve<IMapper>(), container.Resolve<IMapper>());
            Assert.AreNotSame(container.Resolve<IUnitOfWork>(), container.Resolve<IUnitOfWork>());
        }

        [Test]
        public void SimpleInjectorContainerBuilderTest()
        {
            var director = new Director();
            SimpleInjectorContainer container = director.Construct(new SimpleInjectorContainerBuilder());

            Assert.IsInstanceOf<Logger>(container.GetInstance(typeof(ILogger)));
            Assert.IsInstanceOf<Mapper>(container.GetInstance(typeof(IMapper)));
            Assert.IsInstanceOf<UnitOfWork>(container.GetInstance(typeof(IUnitOfWork)));

            Assert.AreSame(container.GetInstance(typeof(ILogger)), container.GetInstance(typeof(ILogger)));
            Assert.AreSame(container.GetInstance(typeof(IMapper)), container.GetInstance(typeof(IMapper)));
            Assert.AreNotSame(container.GetInstance(typeof(IUnitOfWork)), container.GetInstance(typeof(IUnitOfWork)));
        }
    }
}
