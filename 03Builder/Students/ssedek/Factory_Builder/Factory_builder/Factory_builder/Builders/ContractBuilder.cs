using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory_builder.Builders.Interfaces;
using Factory_builder.Models;

namespace Factory_builder.Builders
{
    public class ContractBuilder : BuilderAbstract<Contract>, IContractBuilder
    {
        public ContractBuilder Initialize()
        {
            Prototype = new Contract();
            return this;
        }

        public ContractBuilder SetName(string name = "Contract")
        {

            Prototype.Name = name;
            return this;
        }

        public ContractBuilder SetSize(int size = 24)
        {
            Prototype.Size = size;
            return this;
        }

    }
}
