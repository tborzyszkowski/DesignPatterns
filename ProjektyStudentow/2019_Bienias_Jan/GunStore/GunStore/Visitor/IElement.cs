namespace GunStore.Visitor
{
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}
