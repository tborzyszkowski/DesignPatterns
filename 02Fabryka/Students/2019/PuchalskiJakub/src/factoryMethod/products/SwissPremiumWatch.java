package factoryMethod.products;

import abstractFactory.components.ComponentsFactory;

public class SwissPremiumWatch extends Watch {

    public SwissPremiumWatch(String producer, Float price, String type){
        this.producer = producer;
        this.price = price;
        this.type = type;
    }

}
