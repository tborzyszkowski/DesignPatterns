using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class Invoker {
        private Command _command;

        public void SetCommand(Command command) {
            this._command = command;
        }

        public void ExecuteCommand() {
            _command.Execute();
        }
    }
}
