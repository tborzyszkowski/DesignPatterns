namespace Builder
{
    class Shop
    {
        public void Construct(BuildingBuilder buildingBuilder)
        {
            buildingBuilder.BuildDoors();
            buildingBuilder.BuildFloors();
            buildingBuilder.BuildWindows();
            buildingBuilder.Paint();
        }
    }
}
