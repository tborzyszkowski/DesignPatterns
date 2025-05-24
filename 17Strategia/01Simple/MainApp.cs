using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class MainApp {
        static void Main(string[] args) {
            Context context;
            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            Console.WriteLine("==========");

            // 2nd way
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();
            context.strategy = new ConcreteStrategyB();
            context.ContextInterface();
            context.strategy = new ConcreteStrategyC();
            context.ContextInterface();
        }
    }
}
