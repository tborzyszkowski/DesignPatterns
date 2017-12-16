using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Adapter
{
    public class PersonJSONAdaptee
    {
        public string GetPersonListJSON()
        {
            List<Person> personList = new List<Person>();
            personList.Add(new Person
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Age = 43
            });

            personList.Add(new Person
            {
                FirstName = "Alicja",
                LastName = "Nowak",
                Age = 23
            });

            personList.Add(new Person {
                FirstName = "Andrzej",
                LastName = "Drzewo",
                Age = 34
            });

            dynamic collectionPerson = new
            {
                person = personList
            };

            return JsonConvert.SerializeObject(collectionPerson);
        }
    }
}
