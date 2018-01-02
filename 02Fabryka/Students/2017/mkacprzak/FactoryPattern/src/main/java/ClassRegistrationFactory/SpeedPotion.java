package ClassRegistrationFactory;

public class SpeedPotion extends Potion{


    @Override
    public String toString() {
        return "SpeedPotion";
    }

    @Override
    public Potion createPotion() {
        return new SpeedPotion();
    }

    static
    {

       PotionFactory potionFactory =  PotionFactory.getFactory();
       potionFactory.registerProduct("ID2", new SpeedPotion());
    }
}
