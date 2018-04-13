namespace FluentBuilder
{
    class HouseBuilder : BuildingBuilder
    {
        public HouseBuilder()
        {
            building = new Building("House");
        }

        public override BuildingBuilder BuildDoors()
        {
            building.doors = 2;
            return this;
        }

        public override BuildingBuilder BuildFloors()
        {
            building.floors = 2;
            return this;
        }

        public override BuildingBuilder BuildWindows()
        {
            building.windows = 8;
            return this;
        }

        public override BuildingBuilder Paint()
        {
            building.color = "Green";
            return this;
        }
    }
}
