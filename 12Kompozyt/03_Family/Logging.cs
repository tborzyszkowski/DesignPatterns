using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Utility {
    public static class Logging {
        public static void Log(string value) {
#if DEBUG
            Debug.WriteLine(value);
#else
            Console.WriteLine(value);
#endif
        }
        public static void Log(object value) {
#if DEBUG
            Debug.WriteLine(ObjectDumper.Dump(value));
#else
            Console.WriteLine(ObjectDumper.Dump(value));
#endif
        }
        public static void LineSeparator() {
#if DEBUG
            Debug.WriteLine(new string('-', 20));
#else
            Console.WriteLine(new string('-', 20));
#endif
        }
    }
}
