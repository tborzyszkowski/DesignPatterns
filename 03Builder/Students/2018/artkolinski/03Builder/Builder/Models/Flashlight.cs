using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FluentBuilder.Models
{
    public class Flashlight
    {
        private readonly string _flashlightType;
        private readonly List<Tuple<string,string>> _parts = new List<Tuple<string, string>>();
        public Func<string, Predicate<Tuple<string, string>>> ByKey = i => (c => c.Item1 == i);
        public Flashlight(string flashlightType)
        {
            _flashlightType = flashlightType;
        }

        public string this[string key]
        {
            get { return _parts.Where(a => a.Item1 == key).Select(a => a.Item2).FirstOrDefault(); }
            set
            {   
                if (_parts.Find(a => a.Item1 == key) == null)
                {
                    _parts.Add(new Tuple<string, string>(key, value));
                }
                else
                {
                    var index = _parts.FindIndex(a => a.Item1 == key);
                    _parts[index] = new Tuple<string, string>(key, value);
                }   
            }
        }

        public string GetFlashlightType()
        {
            return _flashlightType;
        }

        public string GetValueByKey(string key)
        {
            string value;
            try
            {
                value = _parts.Find(ByKey(key)).Item2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex);
                value = "Not exist";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                value = ex.ToString();
            }
            return value;
        }
    }
}

