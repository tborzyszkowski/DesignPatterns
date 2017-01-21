using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface ITestDrive
    {
        void RateAfterTestDrive(Car car, int rate);
        void ReserveTestDrive(Car car);
        void GoToTestDrive(Car car);
    }
}
