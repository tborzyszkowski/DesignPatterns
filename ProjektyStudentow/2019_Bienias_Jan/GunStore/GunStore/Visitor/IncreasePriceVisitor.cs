namespace GunStore.Visitor
{
    //Concrete Visitor
    public class IncreasePriceVisitor : IVisitor
    {
        public void Visit(IElement element)
        {
            var gun = element as AbstractGun;
            gun.BasePrice *= 1.25m;
        }
    }
}
