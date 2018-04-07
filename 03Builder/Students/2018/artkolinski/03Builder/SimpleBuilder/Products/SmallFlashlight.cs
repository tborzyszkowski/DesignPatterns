using SimpleBuilder.Models;

namespace SimpleBuilder.Products
{
    public class SmallFlashlight : FlashlightBuilder
    {

        public SmallFlashlight()
        {
            Flashlight = new Flashlight();
        } 
        public override void BuildHost()
        {
            Flashlight["Host"] = "Small Host";
        }

        public override void BuildDriver()
        {
            Flashlight["Driver"] = "Small Driver";
        }

        public override void BuildLed()
        {
            Flashlight["Led"] = "XM-L2";
        }

        public override void BuildBox()
        {
            Flashlight["Box"] = "Small Gift Box";
        }

        public override void SetName()
        {
            Flashlight["Name"] = "Small";
        }

        public override Flashlight GetFlashlight()
        {
            return Flashlight;
        }
    }
}
