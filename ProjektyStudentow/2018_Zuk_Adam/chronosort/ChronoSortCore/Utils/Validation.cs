using ChronoSortCore.Parameters;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChronoSortCore.Utils
{
    public class Validation
    {
        public static Parameter ValidateArgs(string command)
        {
            var args = Regex.Split(command, @"(?=-)").ToList();
            args.RemoveAll(arg => arg == string.Empty);

            if (args.Count == 0)
            {
                Logger.GetLoggerInstance().Error("Invalid number of parameters.");
                return null;
            }
            else
            {
                var source = args[0].ToLower();
                var parameter = ParameterFactory.GetParameter(source);

                if (parameter == null)
                {
                    Logger.GetLoggerInstance().Error(string.Format("Unable to match '{0}' with any known parameter. Type -h/help for manual."));
                    return null;
                }
                return parameter.Validate() ? parameter : null;
            }
        }

        public static bool ValidateIfFileExists(string path)
        {
            if (!File.Exists(path))
            {
                Logger.GetLoggerInstance().Error(string.Format("File not found: {0}", path));
                return false;
            }
            return true;
        }
    }
}
