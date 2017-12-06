package ClassRegistrationFactory;

public class ManaPotion extends Potion{



    @Override
    public String toString() {
        return "ManaPotion";
    }

    @Override
    public Potion createPotion() {
        return new ManaPotion();
    }

    static
    {

        PotionFactory potionFactory =  PotionFactory.getFactory();
        potionFactory.registerProduct("ID1", new ManaPotion());
    }
}
