package FactoryMethod.laboratory;

import FactoryMethod.potion.Great.GreatHealthPotion;
import FactoryMethod.potion.Great.GreatManaPotion;
import FactoryMethod.potion.Great.GreatSpeedPotion;
import FactoryMethod.potion.Potion;

public class GreatPotionLaboratory extends Laboratory{

    Potion boilPotion(String item) {
        Potion potion=null;
        if (item.equals("health")) {
           potion = new GreatHealthPotion();
        } else if (item.equals("mana")) {
            potion = new GreatManaPotion();
        } else if (item.equals("speed")) {
            potion =  new GreatSpeedPotion();
        } else return null;
        
        potion.setSize(500);
        return potion;
    }
}
