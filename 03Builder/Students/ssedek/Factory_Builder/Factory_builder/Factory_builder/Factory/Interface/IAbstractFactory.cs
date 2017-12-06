using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_builder.Factory.Interface
{
    public interface IAbstractFactory<T, TEnum> where T: class
    {
        T Generate(TEnum productType);
        
    }
}
