package AbstractFactory.potion;

import AbstractFactory.ingredientfactory.IngredientFactory;

public class ManaPotion extends Potion{

    IngredientFactory ingredientFactory;

    public ManaPotion(IngredientFactory ingredientFactory)
    {

        this.ingredientFactory=ingredientFactory;
        this.name="Mana Potion";
        this.description="Mana potion desc";
        prepare();
    }

    public void prepare()
    {
        System.out.println("Preparing mana potion");
        stinger = ingredientFactory.createStinger();
        flower = ingredientFactory.createFlower();
        nectar = ingredientFactory.createNectar();
    }
}




