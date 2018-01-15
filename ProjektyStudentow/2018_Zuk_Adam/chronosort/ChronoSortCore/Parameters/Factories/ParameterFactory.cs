using System;
using System.Reflection;
using System.Linq;

namespace ChronoSortCore.Parameters
{
    public class ParameterFactory
    {
        public static Parameter GetParameter(string command)
        {
            // Loading ChronoSortCore assembly is needed for test purposes
            var assembly = Assembly.Load(new AssemblyName("ChronoSortCore"));

            var types = assembly.GetTypes().Where(t => t.GetTypeInfo().BaseType == typeof(Parameter)).ToList();

            Parameter result = null;

            var correctType = types.FirstOrDefault(t =>
            {
                result = Activator.CreateInstance(t) as Parameter;

                var splittedCommand = command.Split(new[] { ' ' }, 2);
                var parameter = splittedCommand.First();

                if (splittedCommand.Count() == 2)
                {
                    result.Value = splittedCommand.Last();
                }

                return parameter == result.ShortOption || parameter == result.LongOption;
            });

            return correctType == null ? null : result;
        }
    }
}
