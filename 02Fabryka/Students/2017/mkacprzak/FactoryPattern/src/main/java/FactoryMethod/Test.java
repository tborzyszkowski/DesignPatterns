package FactoryMethod;

import FactoryMethod.laboratory.GreatPotionLaboratory;
import FactoryMethod.laboratory.Laboratory;
import FactoryMethod.laboratory.SmallPotionLaboratory;
import FactoryMethod.potion.Potion;

public class Test {

    public static void main(String[] args)
    {
        Laboratory greatPotionLaboratory = new GreatPotionLaboratory();
        Laboratory smallPotionLaboratory = new SmallPotionLaboratory();


        Potion greatHealthPotion = greatPotionLaboratory.preparePotion("health");

        System.out.println(greatHealthPotion);
        Potion greatManaPotion = greatPotionLaboratory.preparePotion("mana");
        System.out.println(greatManaPotion);
        Potion greatSpeedPotion = greatPotionLaboratory.preparePotion("speed");
        System.out.println(greatSpeedPotion);
        Potion smallHealthPotion = smallPotionLaboratory.preparePotion("health");
        System.out.println(smallHealthPotion);
        Potion smallManaPotion = smallPotionLaboratory.preparePotion("mana");
        System.out.println(smallManaPotion);
        Potion smallSpeedPotion = smallPotionLaboratory.preparePotion("speed");
        System.out.println(smallSpeedPotion);




    }
}
