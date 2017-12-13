package FactoryMethod.laboratory;


import FactoryMethod.potion.Potion;
import FactoryMethod.potion.Small.SmallHealthPotion;
import FactoryMethod.potion.Small.SmallManaPotion;
import FactoryMethod.potion.Small.SmallSpeedPotion;

public class SmallPotionLaboratory extends Laboratory {

    Potion boilPotion(String item) {

        Potion potion = null;
        if (item.equals("health")) {
            potion =  new SmallHealthPotion();
        } else if (item.equals("mana")) {
            potion =  new SmallManaPotion();
        } else if (item.equals("speed")) {
            potion =  new SmallSpeedPotion();
               }  else return null;

        potion.setSize(200);
        return potion;
    }
}
