using System;
using Factory.SimpleFactory;
using Factory.SimpleFactory.Tablets;

namespace Factory.FactoryMethod
{
    public class TabletFactory : Factory
    {
        private static readonly Lazy<TabletFactory> TabletInstance =
            new Lazy<TabletFactory>(() =>
                Activator.CreateInstance(typeof(TabletFactory),
                    true) as TabletFactory);

        public static TabletFactory Instance
        {
            get { return TabletInstance.Value; }
        }

        private TabletFactory() { }

        protected override IComputer Create(string name)
        {
            switch (name)
            {
                case "Apple":
                    return new AppleTablet();
                case "Huawei":
                    return new HuaweiTablet();
                case "Lenovo":
                    return new LenovoTablet();
                case "Microsoft":
                    return new MicrosoftTablet();
                case "Samsung":
                    return new SamsungTablet();
                default:
                    return null;
            }
        }
    }
}
