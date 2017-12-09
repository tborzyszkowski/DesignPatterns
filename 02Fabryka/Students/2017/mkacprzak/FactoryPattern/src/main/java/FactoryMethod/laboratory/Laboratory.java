package FactoryMethod.laboratory;

import FactoryMethod.potion.Potion;

public abstract class Laboratory {

    abstract Potion boilPotion(String item);

    public Potion preparePotion(String type) {
       Potion potion = boilPotion(type);
        System.out.println("Preparing potion" + potion.getName());
       potion.addMagic();
        System.out.println("Potion is almost ready!");
       return potion;
    }

}
