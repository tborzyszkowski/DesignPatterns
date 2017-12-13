using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Publishing
    {
        string m_name;
        string m_city;

        public string Name {
            get { return m_name; }
            set { m_name = value; }
        }
        public string City {
            get { return m_city; }
            set { m_city = value; }
        }
    }
}
