package AbstractFactory.laboratory;

import AbstractFactory.ingredientfactory.GreatIngredientFactory;
import AbstractFactory.ingredientfactory.IngredientFactory;
import AbstractFactory.potion.HealthPotion;
import AbstractFactory.potion.ManaPotion;
import AbstractFactory.potion.Potion;

public class GreatPotionLaboratory extends Laboratory {


    Potion boilPotion(String item) {
       Potion potion = null;
        IngredientFactory ingredientFactory = new GreatIngredientFactory();

        if(item.equals("health"))
        {

            potion = new HealthPotion(ingredientFactory);
            potion.setName("Great " + potion.getName());


        }
        else if(item.equals("mana"))
        {
            potion = new ManaPotion(ingredientFactory);
            potion.setName("Great " + potion.getName());
        }

        return potion;
    }
}
