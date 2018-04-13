namespace Builder
{
    class HouseBuilder : BuildingBuilder
    {
        public HouseBuilder()
        {
            building = new Building("House");
        }

        public override void BuildDoors()
        {
            building.doors = 2;
        }

        public override void BuildFloors()
        {
            building.floors = 2;
        }

        public override void BuildWindows()
        {
            building.windows = 8;
        }

        public override void Paint()
        {
            building.color = "Green";
        }
    }
}
