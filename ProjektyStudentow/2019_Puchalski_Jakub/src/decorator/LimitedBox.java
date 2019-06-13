package decorator;

import shop.Order;

public class LimitedBox extends WatchDecorator {

    private Order order;

    public LimitedBox(Order order) {
        this.order = order;
    }

    public long getWatchId(){
        return order.getWatchId();

    }

    @Override
    public String about() {
        return order.about() + "+Limited Box" + "\n";
    }

    @Override
    public double cena() {
        return order.cena() + 250;
    }
}
