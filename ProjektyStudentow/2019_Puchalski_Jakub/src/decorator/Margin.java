package decorator;

import shop.Order;
import watchModels.Watch;

public class Margin extends WatchDecorator {

    private Order order;
    private double margin;

    public Margin(Order order, double margin){
        this.order = order;
        this.margin = margin;
    }

    public long getWatchId(){
        return order.getWatchId();
    }

    @Override
    public String about() {
        return order.about() + "Final price = " + (order.cena() + margin) + "\n" + "----------";
    }

    @Override
    public double cena() {
        return order.cena() + margin;
    }
}
