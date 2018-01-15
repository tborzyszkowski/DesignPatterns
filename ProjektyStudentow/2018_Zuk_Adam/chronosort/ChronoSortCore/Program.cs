using ChronoSortCore.Utils;
using System;

namespace ChronoSortCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var newArgs = string.Join(" ", args);

            var parameter = Validation.ValidateArgs(newArgs);

            if (parameter == null)
            {
                return;
            }
            parameter.Execute();
        }
    }
}