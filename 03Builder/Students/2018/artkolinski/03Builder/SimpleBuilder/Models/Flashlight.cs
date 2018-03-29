using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBuilder.Models
{
    public class Flashlight
    {
        private readonly List<Tuple<string,string>> _myDictionary = new List<Tuple<string, string>>();

        public string this[string key]
        {
            get { return _myDictionary.Where(a => a.Item1 == key).Select(a => a.Item2).FirstOrDefault(); }
            set
            {   
                if (_myDictionary.Find(a => a.Item1 == key) == null)
                {
                    _myDictionary.Add(new Tuple<string, string>(key, value));
                }
                else
                {
                    var index = _myDictionary.FindIndex(a => a.Item1 == key);
                    _myDictionary[index] = new Tuple<string, string>(key, value);
                }   
            }
        }
    }
}

