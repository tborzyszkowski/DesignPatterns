package factoryMethod.products;

import abstractFactory.components.ComponentsFactory;

public class JapaneseSportWatch extends Watch {

    public JapaneseSportWatch(String producer, Float price, String type){
        this.producer = producer;
        this.price = price;
        this.type = type;
    }

}
