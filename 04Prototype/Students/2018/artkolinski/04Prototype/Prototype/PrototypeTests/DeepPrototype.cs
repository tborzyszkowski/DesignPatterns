using DeepPrototype.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrototypeTests
{
    [TestClass]
    public class DeepPrototype
    {
        [TestMethod]
        public void ComputerDeepClone()
        {
            #region DefineObject
            var cooling = new Cooling {Model = "Corsair Extreme Cooler H115i" };
            var processor = new Processor
            {
                Cooling = cooling,
                Model = "I9-7920X 2.90GHz, 16.5 MB"
            };
            var motherboard = new Motherboard
            {
                Processor = processor,
                GraphicCard = "GTX 1080 Ti AMP EXTREME",
                Memory = "G.Skill Trident Z RGB DDR4, 8x16GB, 3466MHz"
            };
            var computer = new Computer(motherboard)
            {
                ProjectName = "My dream nr 7005",
                Case = "Obudowa Lian Li DK-03X"
            };
            #endregion
            var deepClone = computer.DeepClone();
            AreNotSame(deepClone, computer);
            AreNotSame(deepClone.Motherboard, computer.Motherboard);
            AreNotSame(deepClone.Motherboard.Processor, computer.Motherboard.Processor);
            AreNotSame(deepClone.Motherboard.Processor.Cooling, computer.Motherboard.Processor.Cooling);
            AreEqual("Corsair Extreme Cooler H115i", deepClone.Motherboard.Processor.Cooling.Model);
            AreEqual("Corsair Extreme Cooler H115i", computer.Motherboard.Processor.Cooling.Model);
            deepClone.Motherboard.Processor.Cooling.Model = "Box";
            AreEqual("Box", deepClone.Motherboard.Processor.Cooling.Model);
            AreEqual("Corsair Extreme Cooler H115i", computer.Motherboard.Processor.Cooling.Model);
        }
        [TestMethod]
        public void ComputerShallowClone()
        {
            #region DefineObject
            var cooling = new Cooling { Model = "Corsair Extreme Cooler H115i" };
            var processor = new Processor
            {
                Cooling = cooling,
                Model = "I9-7920X 2.90GHz, 16.5 MB"
            };
            var motherboard = new Motherboard
            {
                Processor = processor,
                GraphicCard = "GTX 1080 Ti AMP EXTREME",
                Memory = "G.Skill Trident Z RGB DDR4, 8x16GB, 3466MHz"
            };
            var computer = new Computer(motherboard)
            {
                ProjectName = "My dream nr 7005",
                Case = "Obudowa Lian Li DK-03X"
            };
            #endregion
            var shallowClone = computer.ShallowClone() as Computer;
            AreNotSame(shallowClone, computer);
            AreSame(shallowClone.Motherboard, computer.Motherboard);
            AreSame(shallowClone.Motherboard.Processor, computer.Motherboard.Processor);
            AreSame(shallowClone.Motherboard.Processor.Cooling, computer.Motherboard.Processor.Cooling);
            AreEqual("Corsair Extreme Cooler H115i", shallowClone.Motherboard.Processor.Cooling.Model);
            AreEqual("Corsair Extreme Cooler H115i", computer.Motherboard.Processor.Cooling.Model);
            shallowClone.Motherboard.Processor.Cooling.Model = "Box";
            AreEqual("Box", shallowClone.Motherboard.Processor.Cooling.Model);
            AreEqual("Box", computer.Motherboard.Processor.Cooling.Model);
        }
    }
}
