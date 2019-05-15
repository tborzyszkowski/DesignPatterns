using NUnit.Framework;

namespace NestedDeepCopy.Tests
{
    public class NestedDeepCopy
    {
        private Mage _mage;
        private Mage _mageClone;

        [SetUp]
        public void Setup()
        {
            _mage = new Mage("Aharus", new Apprentice(new Cat(new Toy("mouse", 10.99m))));
            _mageClone = _mage.DeepCopy();
        }

        [Test]
        public void Should_AllReferenceFieldsAndObjectsBeDifferent_When_DeepCopy()
        {
            Assert.Multiple(() =>
            {
                Assert.AreNotSame(_mage, _mageClone);
                Assert.AreNotSame(_mage.Name, _mageClone.Name);
                Assert.AreNotSame(_mage.Apprentice, _mageClone.Apprentice);
                Assert.AreNotSame(_mage.Apprentice.Cat, _mageClone.Apprentice.Cat);
                Assert.AreNotSame(_mage.Apprentice.Cat.Toy, _mageClone.Apprentice.Cat.Toy);
                Assert.AreNotSame(_mage.Apprentice.Cat.Toy.Name, _mageClone.Apprentice.Cat.Toy.Name);
            });
        }

        [Test]
        public void Should_ToyPriceBeEqualButNotSame_When_DeepCopy()
        {
            Assert.Multiple(() =>
            {
            Assert.AreNotSame(_mage.Apprentice.Cat.Toy.Price, _mageClone.Apprentice.Cat.Toy.Price);
            Assert.AreEqual(_mage.Apprentice.Cat.Toy.Price, _mageClone.Apprentice.Cat.Toy.Price);
            });
        }
    }
}