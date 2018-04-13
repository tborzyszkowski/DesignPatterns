namespace Builder
{
    class SkyscraperBuilder : BuildingBuilder
    {
        public SkyscraperBuilder()
        {
            building = new Building("Skyscraper");
        }

        public override void BuildDoors()
        {
            building.doors = 6;
        }

        public override void BuildFloors()
        {
            building.floors = 50;
        }

        public override void BuildWindows()
        {
            building.windows = 600;
        }

        public override void Paint()
        {
            building.color = "White";
        }
    }
}
