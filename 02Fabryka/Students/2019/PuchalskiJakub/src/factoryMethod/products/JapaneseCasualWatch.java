package factoryMethod.products;

import abstractFactory.components.ComponentsFactory;

public class JapaneseCasualWatch extends Watch {

    public JapaneseCasualWatch(String producer, Float price, String type){
        this.producer = producer;
        this.price = price;
        this.type = type;
    }

}
