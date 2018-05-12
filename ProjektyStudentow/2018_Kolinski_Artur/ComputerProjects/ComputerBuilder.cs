using ComputerProjects.Models;

namespace ComputerProjects
{
    public abstract class ComputerBuilder
    {
        protected Computer Computer;
        public abstract void AddMotherboardWithProcessor();
        public abstract void AddCase();
        public abstract Computer GetComputer();
    }
}