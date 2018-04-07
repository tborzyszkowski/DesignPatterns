using FluentBuilder.Models;

namespace FluentBuilder
{
    public abstract class FlashlightBuilder
    {
        protected Flashlight flashlight;

        private Flashlight Flashlight => flashlight;
        public abstract FlashlightBuilder BuildHost();
        public abstract FlashlightBuilder BuildDriver();
        public abstract FlashlightBuilder BuildLed();
        public abstract FlashlightBuilder BuildBox();

        public static implicit operator Flashlight(FlashlightBuilder fb)
        {
            return fb.BuildHost()
                .BuildDriver()
                .BuildLed()
                .BuildBox()
                .Flashlight;
        }
    }
}
