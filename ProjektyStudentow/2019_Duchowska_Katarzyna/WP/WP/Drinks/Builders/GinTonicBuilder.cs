using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks.Alcohols;
using WP.Drinks.Softs;


namespace WP.Drinks.Builders
{
    public class GinTonicBuilder : DrinkBuilder
    {
        private static Lazy<GinTonicBuilder> _builder = new Lazy<GinTonicBuilder>(() => new GinTonicBuilder());

        private GinTonicBuilder() { }

        public static GinTonicBuilder Builder
        {
            get { return _builder.Value; }
        }

        public override DrinkBuilder WithAlcohol()
        {
            Drink.Alcohol = new Gin();
            return this;
        }

        public override DrinkBuilder WithSoft()
        {
            Drink.Soft = new Tonic();
            return this;
        }
    }
}
