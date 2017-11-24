package AbstractFactory.laboratory;


import AbstractFactory.ingredientfactory.IngredientFactory;
import AbstractFactory.ingredientfactory.SmallIngredientFactory;
import AbstractFactory.potion.HealthPotion;
import AbstractFactory.potion.ManaPotion;
import AbstractFactory.potion.Potion;

public class SmallPotionLaboratory extends Laboratory {
    Potion boilPotion(String item) {
        Potion potion = null;
        IngredientFactory ingredientFactory = new SmallIngredientFactory();

        if(item.equals("health"))
        {

            potion = new HealthPotion(ingredientFactory);
            potion.setName("Small " + potion.getName());

        }
        else if(item.equals("mana"))
        {
            potion = new ManaPotion(ingredientFactory);
            potion.setName("Small " + potion.getName());
        }

        return potion;
    }
}
