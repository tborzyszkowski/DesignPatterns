package ClassRegistrationFactory;

public class HealthPotion extends Potion {


    static
    {



        PotionFactory potionFactory =  PotionFactory.getFactory();
        potionFactory.registerProduct("ID3", new HealthPotion());
    }
    @Override
    public String toString() {
        return "HealthPotion";
    }

    @Override
    public Potion createPotion() {
        return new HealthPotion();
    }


}
