using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks.Alcohols;
using WP.Drinks.Softs;

namespace WP.Drinks.Builders
{
    public class CubaLibreBuilder : DrinkBuilder
    {
        private static Lazy<CubaLibreBuilder> _builder = new Lazy<CubaLibreBuilder>(() => new CubaLibreBuilder());
        
        private CubaLibreBuilder() {}

        public static CubaLibreBuilder Builder
        {
            get { return _builder.Value; }
        }

        public override DrinkBuilder WithAlcohol()
        {
            Drink.Alcohol = new Rum();
            return this;
        }

        public override DrinkBuilder WithSoft()
        {
            Drink.Soft = new Cola();
            return this;
        }
    }
}
