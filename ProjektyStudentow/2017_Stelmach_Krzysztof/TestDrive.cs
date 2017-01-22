using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class TestDrive
    {
        CarManager carmanager = new CarManager();


        public void RateAfterTestDrive(Car car, int rate)
        {
            Console.WriteLine("Oceniłes " + car.Brand + " " + car.Model + " po jeździe testowej"
                + " na ocenę " + rate);
        }

        public void ReserveTestDrive(Car car)
        {
            Console.WriteLine("Zarezerwowales " + car.Brand + " " + car.Model + " na jazde testową");
        }

        public void GoToTestDrive(Car car)
        {
            Console.WriteLine("Wybrałes sie na jazdę testową : " + car.Brand + " " + car.Model);
        }




    }
}
