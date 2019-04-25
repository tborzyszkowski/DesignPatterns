namespace ShallowCopy
{
    public class Mage : Prototype<Mage>
    {
        public string Name;
        public Apprentice Apprentice;

        public Mage(string name, Apprentice apprentice)
        {
            Name = name;
            Apprentice = apprentice;
        }
    }
}
