using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory_builder.Builders;
using Factory_builder.Builders.Interfaces;
using Factory_builder.Enums;
using Factory_builder.Factory.Interface;
using Factory_builder.Models;

namespace Factory_builder.Factory
{
    public class GenerateDocumentFactory : IAbstractFactory<Document, DOCUMENT_TYPE>
    {
        private readonly ICertificateBuilder _certificateBuilder;
        private readonly IContractBuilder _contractBuilder;

        public GenerateDocumentFactory()

        {
            _certificateBuilder = new CertificateBuilder();
            _contractBuilder = new ContractBuilder();

        }
        public Document Generate(DOCUMENT_TYPE documentType)
        {

            switch (documentType)
            {
                case DOCUMENT_TYPE.Certificate:
                    _certificateBuilder
                        .Initialize()
                        .SetName()
                        .SetSize(24);
                    return _certificateBuilder.GetProduct();

                case DOCUMENT_TYPE.Contract:
                    _contractBuilder
                        .Initialize()
                        .SetName()
                        .SetSize(58);
                    return _contractBuilder.GetProduct();

                default:
                    throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null);
            }

        }
    }
}
