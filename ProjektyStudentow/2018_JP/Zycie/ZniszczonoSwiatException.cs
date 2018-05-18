using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zycie
{
    class ZniszczonoSwiatException:Exception
    {
        public ZniszczonoSwiatException()
        {
        }

        public ZniszczonoSwiatException(string message)
            : base(message)
        {
            System.Console.WriteLine("Zniszczono świat. {0}", message);
        }

        public ZniszczonoSwiatException(string message, Exception inner)
            : base(message, inner)
        {
            System.Console.WriteLine("Zniszczono świat. {0}", message);
        }
    }
}
