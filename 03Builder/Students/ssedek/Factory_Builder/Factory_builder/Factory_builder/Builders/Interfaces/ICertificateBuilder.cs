using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory_builder.Models;

namespace Factory_builder.Builders.Interfaces
{
    public interface ICertificateBuilder : IBuilderAbstract<Certificate>
    {
        CertificateBuilder Initialize();
        CertificateBuilder SetName(string name = "Certificate");
        CertificateBuilder SetSize(int size = 12);

    }
}
