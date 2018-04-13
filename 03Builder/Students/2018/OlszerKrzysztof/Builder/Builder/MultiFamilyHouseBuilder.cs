namespace Builder
{
    class MultiFamilyHouseBuilder : BuildingBuilder
    {
        public MultiFamilyHouseBuilder()
        {
            building = new Building("Multi-Family House");
        }

        public override void BuildDoors()
        {
            building.doors = 6;
        }

        public override void BuildFloors()
        {
            building.floors = 6;
        }

        public override void BuildWindows()
        {
            building.windows = 18;
        }

        public override void Paint()
        {
            building.color = "White";
        }
    }
}
