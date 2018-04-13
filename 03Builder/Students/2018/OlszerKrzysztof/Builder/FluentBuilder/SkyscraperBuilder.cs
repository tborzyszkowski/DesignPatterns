namespace FluentBuilder
{
    class SkyscraperBuilder : BuildingBuilder
    {
        public SkyscraperBuilder()
        {
            building = new Building("Skyscraper");
        }

        public override BuildingBuilder BuildDoors()
        {
            building.doors = 6;
            return this;
        }

        public override BuildingBuilder BuildFloors()
        {
            building.floors = 50;
            return this;
        }

        public override BuildingBuilder BuildWindows()
        {
            building.windows = 600;
            return this;
        }

        public override BuildingBuilder Paint()
        {
            building.color = "White";
            return this;
        }
    }
}
