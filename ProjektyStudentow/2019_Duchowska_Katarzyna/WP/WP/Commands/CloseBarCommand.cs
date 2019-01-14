using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Commands
{
    public class CloseBarCommand : Command
    {
        public CloseBarCommand(IReceiver receiver) : base(receiver) { }

        public override void Execute()
        {
            receiver.Action();
        }
    }
}
