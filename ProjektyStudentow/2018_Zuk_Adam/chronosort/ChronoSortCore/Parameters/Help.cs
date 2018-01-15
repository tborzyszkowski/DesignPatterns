using ChronoSortCore.Utils;
using System;
using System.Linq;
using System.Reflection;

namespace ChronoSortCore.Parameters
{
    public class Help : Parameter
    {
        public Help()
        {
            this.ShortOption = "-h";
            this.LongOption = "-help";
        }

        public override void Execute()
        {
            Logger.GetLoggerInstance().Info(this.GetHelpString());
        }

        public override string GetUsage()
        {
            return string.Format("{0}|{1}            display this manual", this.ShortOption, this.LongOption);
        }

        public override bool Validate()
        {
            return this.Value == null;
        }

        private string GetHelpString()
        {
            var result = "ChronoSort usage:\n\n<executable> [parameter]\n\nAvailable parameters:\n\n";

            // Loading ChronoSortCore assembly is needed for test purposes
            var assembly = Assembly.Load(new AssemblyName("ChronoSortCore"));

            var types = assembly.GetTypes().Where(t => t.GetTypeInfo().BaseType == typeof(Parameter)).ToList();

            foreach (var type in types)
            {
                var param = Activator.CreateInstance(type) as Parameter;

                result += param.GetUsage() + Environment.NewLine;
            }
            return result;
        }
    }
}
