using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface ISubject
    {
        void Attach(Observer observer);

        void Detach(Observer observer);

        void Notify();
    }
}
