using FluentBuilder.Models;

namespace FluentBuilder.Products
{
    public class SmallFlashlight : FlashlightBuilder
    {
        public SmallFlashlight()
        {
            flashlight = new Flashlight("Small");
        } 
        public override FlashlightBuilder BuildHost()
        {
            flashlight["Host"] = "Small Host";
            return this;
        }

        public override FlashlightBuilder BuildDriver()
        {
            flashlight["Driver"] = "Small Driver";
            return this;
        }

        public override FlashlightBuilder BuildLed()
        {
            flashlight["Led"] = "XM-L2";
            return this;
        }

        public override FlashlightBuilder BuildBox()
        {
            flashlight["Box"] = "Small Gift Box";
            return this;
        }
    }
}
