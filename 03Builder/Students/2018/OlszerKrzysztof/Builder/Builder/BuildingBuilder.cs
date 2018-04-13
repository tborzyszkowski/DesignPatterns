namespace Builder
{
    abstract class BuildingBuilder
    {
        protected Building building;

        public Building Building
        {
            get { return building; }
        }

        public abstract void BuildWindows();
        public abstract void BuildDoors();
        public abstract void BuildFloors();
        public abstract void Paint();
    }
}
