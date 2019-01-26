using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.zad2
{
    public class ConnectionAdapter
    {
        public Func<String, bool> SendMessage;

        public ConnectionAdapter(Telephone phone)
        {
            SendMessage = message =>
            {
                try
                {
                    phone.MakeACall(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                return true;
            };
        }


        public ConnectionAdapter(Pidgeon pidgeon)
        {
            SendMessage = message =>
            {
                return pidgeon.Fly(message) > 0;
            };
        }


        public ConnectionAdapter(Email email)
        {
            SendMessage = message =>
            {
                HttpStatusCode code = email.Send(message);
                return code == HttpStatusCode.OK;
            };
        }

    }
}
