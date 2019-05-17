namespace Factory.AbstractFactory
{
    public class EpicCompany : Company
    {
        public EpicCompany(IFactory factory) : base(factory) { }
    }
}
