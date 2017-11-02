using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using singleton;

namespace singletonTests
{
    [TestClass]
    public class CashMachineTests
    {
        [TestMethod]
        public void CheckCashMachineInstancesTests()
        {
            var cashMachineInstance1 = CashMachine.Instance;
            var cashMachineInstance2 = CashMachine.Instance;

            Assert.AreEqual(cashMachineInstance1, cashMachineInstance2);
            cashMachineInstance1.Reset();
        }

        [TestMethod]
        public void OperationsTests()
        {
            var cashMachineInstance1 = CashMachine.Instance;
            var cashMachineInstance2 = CashMachine.Instance;

            cashMachineInstance1.SetMoney(100);
            cashMachineInstance2.GetMoney(50);

            Assert.AreEqual(50, cashMachineInstance1.GetAccount());
            Assert.AreEqual(50, cashMachineInstance2.GetAccount());

            cashMachineInstance1.Reset();
        }

        [TestMethod]
        public void ThreadSafetyTests()
        {
            var cashMachineInstance1 = CashMachine.Instance;
            var thread1 = new Thread(obj => {cashMachineInstance1.SetMoney(100);});

            var cashMachineInstance2 = CashMachine.Instance;
            var thread2 = new Thread(obj => { cashMachineInstance2.GetMoney(50); });

            thread1.Start();
            thread2.Start();

            while (thread1.ThreadState == ThreadState.Stopped && thread2.ThreadState == ThreadState.Stopped)
            {
                Assert.AreEqual(50, cashMachineInstance1.GetAccount());
                Assert.AreEqual(50, cashMachineInstance2.GetAccount());
            }
            cashMachineInstance1.Reset();
        }
    }
}
