using System.Threading.Tasks;
using NUnit.Framework;

namespace Inheritance.Tests
{
    public class Inheritance
    {
        [Test]
        public void Should_ReturnSameInstance_When_ParallelThreads()
        {
            Parent a = null;
            Parent b = null;

            Parallel.Invoke(
                () => { a = Son.Instance; },
                () => { b = Grandson.Instance; }
            );

            Assert.Multiple(() =>
            {
                Assert.AreSame(a, Parent.Instance);
                Assert.AreSame(b, Parent.Instance);
                Assert.AreEqual(1, Parent.Counter); 

                Assert.AreEqual(a.GetHashCode(), Parent.Instance.GetHashCode());
                Assert.AreEqual(b.GetHashCode(), Parent.Instance.GetHashCode());
                Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
            });
        }
    }
}