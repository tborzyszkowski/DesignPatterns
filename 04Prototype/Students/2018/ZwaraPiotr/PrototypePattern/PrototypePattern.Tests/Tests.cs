using System.Collections.Generic;

using NUnit.Framework;

using PrototypePattern.Abstraction;
using PrototypePattern.Implementation;

namespace PrototypePattern.Tests
{
    [TestFixture]
    internal class Tests
    {
        private PrototypeUsingSerialization prototypeUsingSerialization;
        private PrototypeUsingReflection prototypeUsingReflection;

        [SetUp]
        public void SetUp()
        {
            this.prototypeUsingSerialization = new PrototypeUsingSerialization
            {
                Number = 99,
                Text = "Test String",
                ReferenceObject = new ReferenceObject { Text = "Some Text" },
                Collection = new List<ReferenceObject>
                {
                    new ReferenceObject { Text = "1" },
                    new ReferenceObject { Text = "2" }
                }
            };

            this.prototypeUsingReflection = new PrototypeUsingReflection
            {
                Number = 99,
                Text = "Test String",
                ReferenceObject = new ReferenceObject { Text = "Some Text" },
                Collection = new List<ReferenceObject>
                {
                    new ReferenceObject { Text = "1" },
                    new ReferenceObject { Text = "2" }
                }
            };
        }

        [Test]
        public void TestPrototypeUsingSerialization()
        {
            PrototypeUsingSerialization cloned = this.prototypeUsingSerialization.DeepClone();

            Assert.AreEqual(cloned.Number, this.prototypeUsingSerialization.Number);
            Assert.AreNotSame(cloned.Number, this.prototypeUsingSerialization.Number);

            Assert.AreEqual(cloned.Text, this.prototypeUsingSerialization.Text);
            Assert.AreNotSame(cloned.Text, this.prototypeUsingSerialization.Text);

            Assert.AreEqual(cloned.ReferenceObject.Text, this.prototypeUsingSerialization.ReferenceObject.Text);
            Assert.AreNotSame(cloned.ReferenceObject, this.prototypeUsingSerialization.ReferenceObject);

            Assert.AreNotSame(cloned.Collection, this.prototypeUsingSerialization.Collection);

            Assert.AreEqual(cloned.Collection[0].Text, this.prototypeUsingSerialization.Collection[0].Text);
            Assert.AreNotSame(cloned.Collection[0], this.prototypeUsingSerialization.Collection[0]);
        }

        [Test]
        public void TestPrototypeUsingReflection()
        {
            PrototypeUsingReflection cloned = this.prototypeUsingReflection.DeepClone();

            Assert.AreEqual(cloned.Number, this.prototypeUsingReflection.Number);
            Assert.AreNotSame(cloned.Number, this.prototypeUsingReflection.Number);

            Assert.AreEqual(cloned.Text, this.prototypeUsingReflection.Text);
            Assert.AreNotSame(cloned.Text, this.prototypeUsingReflection.Text);

            Assert.AreEqual(cloned.ReferenceObject.Text, this.prototypeUsingReflection.ReferenceObject.Text);
            Assert.AreNotSame(cloned.ReferenceObject, this.prototypeUsingReflection.ReferenceObject);

            Assert.AreNotSame(cloned.Collection, this.prototypeUsingReflection.Collection);

            Assert.AreEqual(cloned.Collection[0].Text, this.prototypeUsingReflection.Collection[0].Text);
            Assert.AreNotSame(cloned.Collection[0], this.prototypeUsingReflection.Collection[0]);
        }

        [Test]
        public void CanCloneCycleUsingSerialization()
        {
            this.prototypeUsingSerialization.ReferenceObject.Dynamic = this.prototypeUsingSerialization;
            PrototypeUsingSerialization cloned = this.prototypeUsingSerialization.DeepClone();
            Assert.AreSame(cloned, cloned.ReferenceObject.Dynamic);
        }

        [Test]
        public void CanCloneCycleUsingReflection()
        {
            this.prototypeUsingReflection.ReferenceObject.Dynamic = this.prototypeUsingReflection;
            PrototypeUsingReflection cloned = this.prototypeUsingReflection.DeepClone();
            Assert.AreSame(cloned, cloned.ReferenceObject.Dynamic);
        }
    }
}
