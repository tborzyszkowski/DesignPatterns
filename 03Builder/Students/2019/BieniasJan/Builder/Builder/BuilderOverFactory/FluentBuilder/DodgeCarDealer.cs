namespace Builder.BuilderOverFactory.FluentBuilder
{
    public class DodgeCarDealer
    {
        public Dodge Construct(DodgeBuilder dodgeBuilder)
        {
            return dodgeBuilder;
        }
    }
}
