package AbstractFactory.ingredientfactory;

import AbstractFactory.ingredient.flower.Flower;
import AbstractFactory.ingredient.flower.PagodaFlower;
import AbstractFactory.ingredient.nectar.FloralNectar;
import AbstractFactory.ingredient.nectar.Nectar;
import AbstractFactory.ingredient.stinger.HornetStinger;
import AbstractFactory.ingredient.stinger.Stinger;

public class SmallIngredientFactory implements  IngredientFactory{
    public Stinger createStinger() {
        return new HornetStinger();
    }

    public Flower createFlower() {
        return new PagodaFlower();
    }

    public Nectar createNectar() {
        return new FloralNectar();
    }


}
