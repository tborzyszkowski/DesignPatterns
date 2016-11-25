using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank {
    class MainApp {
        static void Main() {
            // Facade
            Mortgage mortgage = new Mortgage();

            // Evaluate mortgage eligibility for customer
            Customer customer = new Customer("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));

            // Wait for user
            Console.ReadKey();
        }
    }
}
