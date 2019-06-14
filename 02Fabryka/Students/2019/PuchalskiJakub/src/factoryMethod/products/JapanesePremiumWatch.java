package factoryMethod.products;

import abstractFactory.components.ComponentsFactory;

public class JapanesePremiumWatch extends Watch {

    public JapanesePremiumWatch(String producer, Float price, String type){
        this.producer = producer;
        this.price = price;
        this.type = type;
    }

}
