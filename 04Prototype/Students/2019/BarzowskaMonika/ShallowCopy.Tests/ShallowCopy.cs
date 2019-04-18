using NUnit.Framework;

namespace ShallowCopy.Tests
{
    public class ShallowCopy
    {
        private Mage _mage;
        private Mage _mageClone;

        [SetUp]
        public void Setup()
        {
            _mage = new Mage("Aharus", new Apprentice(new Cat(new Toy("mouse", 10.99m))));
            _mageClone = _mage.ShallowCopy();
        }

        [Test]
        public void Should_ObjectsBeDifferent_When_ShallowCopy()
        {
            Assert.AreNotSame(_mage, _mageClone);
        }

        [Test]
        public void Should_AllReferenceFieldsBeSame_When_ShallowCopy()
        {
            Assert.Multiple(() =>
            {
                Assert.AreSame(_mage.Name, _mageClone.Name);
                Assert.AreSame(_mage.Apprentice, _mageClone.Apprentice);
                Assert.AreSame(_mage.Apprentice.Cat, _mageClone.Apprentice.Cat);
                Assert.AreSame(_mage.Apprentice.Cat.Toy, _mageClone.Apprentice.Cat.Toy);
                Assert.AreSame(_mage.Apprentice.Cat.Toy.Name, _mageClone.Apprentice.Cat.Toy.Name);
            });
        }

        [Test]
        public void Should_ToyPriceBeEqualButNotSame_When_ShallowCopy()
        {
            Assert.Multiple(() =>
            {
                Assert.AreNotSame(_mage.Apprentice.Cat.Toy.Price, _mageClone.Apprentice.Cat.Toy.Price);
                Assert.AreEqual(_mage.Apprentice.Cat.Toy.Price, _mageClone.Apprentice.Cat.Toy.Price);
            });
        }
    }
}