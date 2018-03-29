using SimpleBuilder.Models;

namespace SimpleBuilder
{
    public abstract class FlashlightBuilder
    {
        protected Flashlight Flashlight;
        public abstract void BuildHost();
        public abstract void BuildDriver();
        public abstract void BuildLed();
        public abstract void BuildBox();
        public abstract void SetName();
        public abstract Flashlight GetFlashlight();
    }
}
