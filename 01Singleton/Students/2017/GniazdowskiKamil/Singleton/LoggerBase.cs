using System;
using System.IO;

namespace Singleton
{
    public abstract class LoggerBase<T> where T : class, new()
    {
        private static T _instance = null;
        protected abstract string Path { get; set; }
        private string _fileName = "log.txt";

        public static string LastLog { get; private set; }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            if (!File.Exists(Path + _fileName))
            {
                Directory.CreateDirectory(Path);
                var file = File.Create(Path + _fileName);
                file.Close();
            }
            using (StreamWriter writer = new StreamWriter(Path + _fileName, true))
            {
                writer.WriteLine(DateTime.Now + " : " + message);
            }
            LastLog = message;
        }
    }
}
