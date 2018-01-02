using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory_builder.Enums;
using Factory_builder.Factory;
using Factory_builder.Models;

namespace Factory_builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new GenerateDocumentFactory();
            var certyficate = factory.Generate(DOCUMENT_TYPE.Certificate);
            var contract = factory.Generate(DOCUMENT_TYPE.Contract);

            Console.WriteLine(certyficate.Name);
            Console.WriteLine(certyficate.Size);


            Console.WriteLine(contract.Name);
            Console.WriteLine(contract.Size);
        }
    }
}
