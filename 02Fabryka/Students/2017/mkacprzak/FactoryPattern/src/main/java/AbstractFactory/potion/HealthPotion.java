package AbstractFactory.potion;

import AbstractFactory.ingredientfactory.IngredientFactory;

public class HealthPotion extends Potion{

    IngredientFactory ingredientFactory;

    public HealthPotion(IngredientFactory ingredientFactory)
    {
        this.ingredientFactory=ingredientFactory;
        this.name="Health Potion";
        this.description="Health potion desc";
        prepare();
    }

    public void prepare()
    {
        System.out.println("Preparing Health potion");
        stinger = ingredientFactory.createStinger();
        flower = ingredientFactory.createFlower();
        nectar = ingredientFactory.createNectar();
    }
}
