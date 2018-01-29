using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Interfaces
{
    public abstract class AbstractCommunication
    {
        public abstract void CreatServer();

        public abstract void CloseServer();
    }
}
