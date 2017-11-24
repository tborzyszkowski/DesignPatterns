using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02DataOperations {

    // The 'Abstraction' class
    class CustomersBase {
        protected string group;

        public CustomersBase(string group) {
            this.group = group;
        }

        // Property
        public DataObject Data { get; set; }

        public virtual void Next() {
            Data.NextRecord();
        }

        public virtual void Prior() {
            Data.PriorRecord();
        }

        public virtual void Add(string customer) {
            Data.AddRecord(customer);
        }

        public virtual void Delete(string customer) {
            Data.DeleteRecord(customer);
        }

        public virtual void Show() {
            Data.ShowRecord();
        }

        public virtual void ShowAll() {
            Console.WriteLine("Customer Group: " + group);
            Data.ShowAllRecords();
        }
    }
}
