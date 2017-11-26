package AbstractFactory.ingredientfactory;

import AbstractFactory.ingredient.flower.Flower;
import AbstractFactory.ingredient.flower.LotusFlower;
import AbstractFactory.ingredient.nectar.Nectar;
import AbstractFactory.ingredient.nectar.SeptalNectar;
import AbstractFactory.ingredient.stinger.ScorpionStinger;
import AbstractFactory.ingredient.stinger.Stinger;

public class GreatIngredientFactory implements IngredientFactory {
    public Stinger createStinger() {
        return  new ScorpionStinger();
    }

    public Flower createFlower()
    {
        return new LotusFlower();
    }

    public Nectar createNectar() {
        return new SeptalNectar();
    }


}
