namespace ComputerProjects
{
    public class ComputerCreator
    {
        public void CreateComputer(ComputerBuilder computerBuilder)
        {
            computerBuilder.AddCase();
            computerBuilder.AddMotherboardWithProcessor();
        }
    }
}