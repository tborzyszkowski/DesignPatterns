using Ceramics.Factories;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class SingletonTests
    {
        [Test]
        public void TestSingletonPoland()
        {
            CerluxPoland cerluxPoland = CerluxPoland.Instance;
            CerluxPoland cerluxPoland2 = CerluxPoland.Instance;

            Assert.AreSame(cerluxPoland, cerluxPoland2);
        }

        [Test]
        public void TestSingletonChina()
        {
            TaociChina taociChina = TaociChina.Instance;
            TaociChina taociChina1 = TaociChina.Instance;

            Assert.AreSame(taociChina, taociChina1);
        }

        [Test]
        public void TestSingletonWithParaller()
        {
            TaociChina a = null;
            TaociChina b = null;

            Parallel.Invoke(
                () => { b = TaociChina.Instance; },
                () => { a = TaociChina.Instance; }
            );

            Assert.IsTrue(object.ReferenceEquals(a, b));
        }
    }
}