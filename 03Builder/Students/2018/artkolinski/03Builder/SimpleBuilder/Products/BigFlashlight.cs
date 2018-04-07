using SimpleBuilder.Models;

namespace SimpleBuilder.Products
{
    public class BigFlashlight : FlashlightBuilder
    {
        public BigFlashlight()
        {
            Flashlight = new Flashlight();
        }
        public override void BuildHost()
        {
            Flashlight["Host"] = "Big Host";
        }

        public override void BuildDriver()
        {
            Flashlight["Driver"] = "Big Driver";
        }

        public override void BuildLed()
        {
            Flashlight["Led"] = "XHP-70";
        }

        public override void BuildBox()
        {
            Flashlight["Box"] = "Big Gift Box";
        }

        public override void SetName()
        {
            Flashlight["Name"] = "Big";
        }

        public override Flashlight GetFlashlight()
        {
            return Flashlight;
        }
    }
}
