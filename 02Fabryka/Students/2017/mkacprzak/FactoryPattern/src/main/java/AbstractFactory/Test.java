package AbstractFactory;

import AbstractFactory.laboratory.GreatPotionLaboratory;
import AbstractFactory.laboratory.SmallPotionLaboratory;
import AbstractFactory.potion.Potion;

public class Test {


    public static void main(String[] args)
    {

        GreatPotionLaboratory greatPotionLaboratory = new GreatPotionLaboratory();
        SmallPotionLaboratory smallPotionLaboratory = new SmallPotionLaboratory();


        Potion potion = greatPotionLaboratory.preparePotion("health");
        System.out.println(potion);
        potion = greatPotionLaboratory.preparePotion("mana");
        System.out.println(potion);
        potion = smallPotionLaboratory.preparePotion("health");
        System.out.println(potion);
        potion = smallPotionLaboratory.preparePotion("mana");
        System.out.println(potion);
    }
}
