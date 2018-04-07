using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.Models;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrototypeTests
{
    [TestClass]
    public class Prototype
    {
        [TestMethod]
        public void ComputerDeepClone()
        {
            var motherboard = new Motherboard
            {
                Processor = "Intel i7",
                GraphicCard = "Titan X",
                Memory = "32GB DDR4"
            };
            var computer = new Computer(motherboard)
            {
                ProjectName = "Test",
                Case = "Zalman Z9"
            };
            var deepClone = computer.DeepClone() as Computer;
            AreEqual("Test", deepClone.ProjectName);
            AreEqual("Zalman Z9", deepClone.Case);
            AreEqual("Intel i7", deepClone.Motherboard.Processor);
            AreEqual("Titan X", deepClone.Motherboard.GraphicCard);
            AreEqual("32GB DDR4", deepClone.Motherboard.Memory);
            AreNotSame(deepClone,computer);
            AreNotSame(deepClone.Motherboard, computer.Motherboard);
        }
        [TestMethod]
        public void ComputerShallowClone()
        {
            var motherboard = new Motherboard
            {
                Processor = "Intel i7",
                GraphicCard = "Titan X",
                Memory = "32GB DDR4"
            };
            var computer = new Computer(motherboard)
            {
                ProjectName = "Test",
                Case = "Zalman Z9"
            };
            var shallowClone = computer.ShallowClone() as Computer;
            AreEqual("Test", shallowClone.ProjectName);
            AreEqual("Zalman Z9", shallowClone.Case);
            AreEqual("Intel i7", shallowClone.Motherboard.Processor);
            AreEqual("Titan X", shallowClone.Motherboard.GraphicCard);
            AreEqual("32GB DDR4", shallowClone.Motherboard.Memory);
            AreNotSame(shallowClone, computer);
            AreSame(shallowClone.Motherboard, computer.Motherboard);
        }
    }
}
