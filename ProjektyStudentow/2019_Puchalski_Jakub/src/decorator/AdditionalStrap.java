package decorator;

import shop.Order;

public class AdditionalStrap extends WatchDecorator {

    private Order order;

    public AdditionalStrap(Order order) {
        this.order = order;
    }

    public long getWatchId(){
        return order.getWatchId();
    }

    @Override
    public String about() {
        return order.about() + "+additionalStrap" + "\n";
    }

    @Override
    public double cena() {
        return order.cena() + 400;
    }
}
