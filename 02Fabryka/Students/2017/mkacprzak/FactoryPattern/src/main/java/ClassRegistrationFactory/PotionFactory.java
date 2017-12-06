package ClassRegistrationFactory;

import java.util.HashMap;
import java.util.Map;


public class PotionFactory {


    private PotionFactory() {}

    private  Map<String, Potion> registeredPotions= new HashMap<>();

    public void registerProduct (String id, Potion potion) {
        registeredPotions.put(id, potion);

    }

    public Potion createPotion(String id)
    {

        return registeredPotions.get(id).createPotion();
    }


    private static class FactoryHelper{
        private static final PotionFactory FACTORY = new PotionFactory();
    }

    public static PotionFactory getFactory()
    {
        return FactoryHelper.FACTORY;
    }
}
