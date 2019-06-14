package abstractFactory.products;

import abstractFactory.components.ComponentsFactory;

public class JapaneseCasualWatch extends Watch {

    public JapaneseCasualWatch(String producer, Float price, ComponentsFactory componentsFactory){
        this.producer = producer;
        this.price = price;
        type = componentsFactory.createType();
        movement = componentsFactory.createMovement();
        glass = componentsFactory.createGlass();
        strap = componentsFactory.createStrap();
    }

}
