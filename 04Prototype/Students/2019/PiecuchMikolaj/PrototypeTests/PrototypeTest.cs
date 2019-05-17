using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype;

namespace PrototypeTests
{
    [TestClass]
    public class PrototypeTest
    {
        private VirtualMachineManager manager = new VirtualMachineManager();

        [TestMethod]
        public void DeepPrototype()
        {
            var vm1 = manager["Test-Win10"];
            var vm2 = manager["Test-Win10"];

            Assert.AreNotSame(vm1, vm2);
            CollectionAssert.AreNotEquivalent(vm1.Controllers.ToList(), vm2.Controllers.ToList());
            CollectionAssert.AreNotEquivalent(vm1.Controllers.SelectMany(x => x.Disks).ToList(), vm2.Controllers.SelectMany(x => x.Disks).ToList());
        }
    }
}
