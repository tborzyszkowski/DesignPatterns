package AbstractFactory.ingredientfactory;

import AbstractFactory.ingredient.flower.Flower;
import AbstractFactory.ingredient.nectar.Nectar;
import AbstractFactory.ingredient.stinger.Stinger;

public interface IngredientFactory {

    public Stinger createStinger();
    public Flower createFlower();
    public Nectar createNectar();

}
