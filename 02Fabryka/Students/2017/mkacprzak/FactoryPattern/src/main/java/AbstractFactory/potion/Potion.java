package AbstractFactory.potion;

import AbstractFactory.ingredient.flower.Flower;
import AbstractFactory.ingredient.nectar.Nectar;
import AbstractFactory.ingredient.stinger.Stinger;

public abstract class Potion {

    protected Stinger stinger;
    protected Nectar nectar;
    protected Flower flower;

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    protected String description;
    protected String name;

    @Override
    public String toString() {
        return "Potion{" +
                "stinger=" + stinger +
                ", nectar=" + nectar +
                ", flower=" + flower +
                ", description='" + description + '\'' +
                ", name='" + name + '\'' +
                '}';
    }
}
