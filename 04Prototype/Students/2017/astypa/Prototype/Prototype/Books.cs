using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class BookOne 
    {
        Publishing m_publishing = new Publishing();
        public string Name { get; set; }
        public string Type { get; set; }
        public Publishing Publishing
        {
            get { return m_publishing; }
            set { m_publishing = value; }
        }
    }

    public class BookTwo 
    {
        public BookOne objOne;
        Publishing m_publishing = new Publishing();
   
        public Publishing Publishing {
            get { return m_publishing; }
            set { m_publishing = value; }
        }

        public BookTwo()
        {
            objOne = new BookOne();
        }


        public BookTwo DeepCopy()
        {
            BookTwo cloned = new BookTwo();
            cloned.objOne.Name = this.objOne.Name;
            cloned.objOne.Type = this.objOne.Type;

            cloned.Publishing = new Publishing();
            cloned.Publishing.Name = this.Publishing.Name;
            cloned.Publishing.City = this.Publishing.City;

            return cloned;
        }

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
