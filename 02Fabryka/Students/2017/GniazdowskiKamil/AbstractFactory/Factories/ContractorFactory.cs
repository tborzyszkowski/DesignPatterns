using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Db;
using AbstractFactory.Model;

namespace AbstractFactory.Factories
{
    class ContractorFactory : IQueryFactory
    {
        public void PrepareQuery(IEntity entity, ref Insert query)
        {
            query.PrepareQuery(entity as Contractor);
        }

        public void PrepareQuery(IEntity entity, ref Select query)
        {
            query.PrepareQuery(entity as Contractor);
        }
    }
}
