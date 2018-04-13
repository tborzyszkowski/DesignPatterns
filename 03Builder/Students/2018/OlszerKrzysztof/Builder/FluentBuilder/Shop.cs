namespace FluentBuilder
{
    class Shop
    {
        public Building Construct(BuildingBuilder buildingBuilder)
        {
            return buildingBuilder;
        }
    }
}
