namespace SimpleBuilder
{
    public class ProjectManager
    {
        public void Construct(FlashlightBuilder flashlightBuilder)
        {
            flashlightBuilder.BuildBox();
            flashlightBuilder.BuildDriver();
            flashlightBuilder.BuildHost();
            flashlightBuilder.BuildLed();
            flashlightBuilder.SetName();
        }
        public void PartialConstruct(FlashlightBuilder flashlightBuilder)
        {
            flashlightBuilder.BuildLed();
            flashlightBuilder.SetName();
        }
        public void ConstructEmptyWithName(FlashlightBuilder flashlightBuilder)
        {
            flashlightBuilder.SetName();
        }
    }
}
