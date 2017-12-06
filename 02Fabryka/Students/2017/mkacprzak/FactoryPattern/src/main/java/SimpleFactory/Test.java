package SimpleFactory;

public class Test {

    public static void main(String[] args)
    {

        PotionFactory potionFactory = new PotionFactory();

        PotionLaboratory potionLaboratory = new PotionLaboratory(potionFactory);


        Potion healthPotion = potionLaboratory.boilPotion("health");
        System.out.println(healthPotion);
        Potion manaPotion = potionLaboratory.boilPotion("mana");
        System.out.println(manaPotion);
        Potion speedPotion = potionLaboratory.boilPotion("speed");
        System.out.println(speedPotion);
        Potion mysteriousPotion = potionLaboratory.boilPotion("mysterious");
        System.out.println(mysteriousPotion);





    }
}
