using FluentBuilder.Models;

namespace FluentBuilder.Products
{
    public class BigFlashlight : FlashlightBuilder
    {
        public BigFlashlight()
        {
            flashlight = new Flashlight("Big");
        }
        public override FlashlightBuilder BuildHost()
        {
            flashlight["Host"] = "Big Host";
            return this;
        }

        public override FlashlightBuilder BuildDriver()
        {
            flashlight["Driver"] = "Big Driver";
            return this;
        }

        public override FlashlightBuilder BuildLed()
        {
            flashlight["Led"] = "XHP-70";
            return this;
        }

        public override FlashlightBuilder BuildBox()
        {
            flashlight["Box"] = "Big Gift Box";
            return this;
        }
    }
}
