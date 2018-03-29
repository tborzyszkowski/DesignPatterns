using FluentBuilder.Models;

namespace FluentBuilder
{
    public class ProjectManager
    {
        public Flashlight Construct(FlashlightBuilder flashlightBuilder)
        {
            return flashlightBuilder;
        }
    }
}
