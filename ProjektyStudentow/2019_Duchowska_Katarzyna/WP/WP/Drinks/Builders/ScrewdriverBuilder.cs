using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks.Alcohols;
using WP.Drinks.Softs;


namespace WP.Drinks.Builders
{
    public class ScrewdriverBuilder : DrinkBuilder
    {
        private static Lazy<ScrewdriverBuilder> _builder = new Lazy<ScrewdriverBuilder>(() => new ScrewdriverBuilder());

        private ScrewdriverBuilder() { }

        public static ScrewdriverBuilder Builder
        {
            get { return _builder.Value; }
        }

        public override DrinkBuilder WithAlcohol()
        {
            Drink.Alcohol = new Vodka();
            return this;
        }

        public override DrinkBuilder WithSoft()
        {
            Drink.Soft = new Juice("Orange");
            return this;
        }
    }
}
