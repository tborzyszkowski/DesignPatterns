namespace GunStore.Visitor
{
    //Concrete Visitor
    public class BargainPriceVisitor : IVisitor
    {
        public void Visit(IElement element)
        {
            var gun = element as AbstractGun;
            gun.BasePrice *= 0.8m;
        }
    }
}
