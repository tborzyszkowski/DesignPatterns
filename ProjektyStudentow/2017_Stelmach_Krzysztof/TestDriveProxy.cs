using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class TestDriveProxy : ITestDrive
    {
        private TestDrive _testDrive = new TestDrive();


        public void RateAfterTestDrive(Car car, int rate)
        {
            _testDrive.RateAfterTestDrive(car, rate);
        }

        public void ReserveTestDrive(Car car)
        {
            _testDrive.ReserveTestDrive(car);
        }

        public void GoToTestDrive(Car car)
        {
            _testDrive.GoToTestDrive(car);
        }
    }
}
