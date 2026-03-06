using FactoryPattern.Domain.Abstraction;

namespace FactoryPattern.Domain.Extensions
{
    public static class ComputerExtensions
    {
        public static string GetDescription(this IComputer pc)
        {
            string description = $"procucer {pc.Producer}: cpu {pc.CPUFrequency} GHz, ram {pc.RAM} GB, storage {pc.Storage}";

            if (pc is IGamingPC gamingPc)
                description += $", gpu: {gamingPc.DedicatedGraphicsCard}";

            if (pc is IWorkStation workStation)
                description += $", raid: {workStation.RaidConfiguration}";

            return description;
        }
    }
}
