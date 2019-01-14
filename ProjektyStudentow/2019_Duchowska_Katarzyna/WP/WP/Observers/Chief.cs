using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Commands;
using WP.Drinks;

namespace WP.Observers
{
    public class Chief : Observer, IInvoker
    {
        public double Income = 0;
        public readonly double MaxIncome = 1000;

        Command Command;
        Barman Barman;

        public override void Update(double price)
        {
            Income += price;
            if (Income > MaxIncome)
            {
                ExecuteCommand(Command);
            }
        }

        public void SetCommand(Command command)
        {
            Command = command;
        }

        public void ExecuteCommand(Command command)
        {
            if (Barman == null)
            {
                Console.WriteLine("Brak barmana - nikt nie zamknie");
                return;
            }

            command.Execute();
        }

        public Barman HireBarman()
        {
            Barman = new Barman(this);
            SetCommand(new CloseBarCommand(Barman));
            return Barman;
        }
    }
}
