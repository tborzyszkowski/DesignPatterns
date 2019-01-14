using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.zad2
{
    public class Email
    {
        public HttpStatusCode Send(String message)
        {
            Console.WriteLine("Sending message... " + message);

            Random rand = new Random();
            bool sthWentWrong = rand.Next(100) < 30;
            if (sthWentWrong)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.OK;
        }
    }
}
