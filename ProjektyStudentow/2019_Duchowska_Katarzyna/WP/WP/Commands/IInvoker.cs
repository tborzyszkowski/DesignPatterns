using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Commands
{
    public interface IInvoker
    {
        void SetCommand(Command command);
        void ExecuteCommand(Command command);
    }
}
