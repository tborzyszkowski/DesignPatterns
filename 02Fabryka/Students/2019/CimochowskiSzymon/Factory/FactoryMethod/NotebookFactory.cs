using System;
using Factory.SimpleFactory;
using Factory.SimpleFactory.Notebooks;

namespace Factory.FactoryMethod
{
    public class NotebookFactory : Factory
    {
        private static readonly Lazy<NotebookFactory> NotebookInstance = 
            new Lazy<NotebookFactory>(() =>
                Activator.CreateInstance(typeof(NotebookFactory),
                    true) as NotebookFactory);

        public static NotebookFactory Instance
        {
            get { return NotebookInstance.Value;}
        }

        private NotebookFactory() { }

        protected override IComputer Create(string name)
        {
            switch (name)
            {
                case "Acer":
                    return new AcerNotebook();
                case "ASUS":
                    return new AsusNotebook();
                case "Dell":
                    return new DellNotebook();
                case "Lenovo":
                    return new LenovoNotebook();
                case "MSI":
                    return new MSINotebook();
                default:
                    return null;
            }
        }
    }
}
