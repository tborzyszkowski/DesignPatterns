using Printer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer.API
{
    public class Unsubscriber : IDisposable
    {
        private HashSet<IObserver<PrinterInfo>> _observers;
        private IObserver<PrinterInfo> _observer;

        public Unsubscriber(HashSet<IObserver<PrinterInfo>> observers, IObserver<PrinterInfo> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
