namespace FluentBuilder
{
    abstract class BuildingBuilder
    {
        protected Building building;

        public Building Building
        {
            get { return building; }
        }

        public abstract BuildingBuilder BuildWindows();
        public abstract BuildingBuilder BuildDoors();
        public abstract BuildingBuilder BuildFloors();
        public abstract BuildingBuilder Paint();

        public static implicit operator Building(BuildingBuilder bb)
        {
            return bb.BuildWindows().BuildDoors().BuildFloors().Paint().Building;
        }
    }
}
