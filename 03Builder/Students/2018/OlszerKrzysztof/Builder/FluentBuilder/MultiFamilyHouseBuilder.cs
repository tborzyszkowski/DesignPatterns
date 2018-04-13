namespace FluentBuilder
{
    class MultiFamilyHouseBuilder : BuildingBuilder
    {
        public MultiFamilyHouseBuilder()
        {
            building = new Building("Multi-Family House");
        }

        public override BuildingBuilder BuildDoors()
        {
            building.doors = 6;
            return this;
        }

        public override BuildingBuilder BuildFloors()
        {
            building.floors = 6;
            return this;
        }

        public override BuildingBuilder BuildWindows()
        {
            building.windows = 18;
            return this;
        }

        public override BuildingBuilder Paint()
        {
            building.color = "White";
            return this;
        }
    }
}
