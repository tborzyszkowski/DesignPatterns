package SimpleFactory;

public class PotionLaboratory {

    private PotionFactory potionFactory;

    public PotionLaboratory(PotionFactory potionFactory) {
        this.potionFactory = potionFactory;
    }

    public Potion boilPotion(String type)
    {

        Potion potion = potionFactory.createPotion(type);
        potion.addMagic();

        return potion;

    }
}
