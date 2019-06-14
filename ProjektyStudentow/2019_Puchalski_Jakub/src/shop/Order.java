package shop;

import watchModels.Watch;

public class Order {

    public Watch watch;
    public double price;
    public boolean gift;
    public boolean additionalStrap;
    public boolean limitedBox;

    public Order(){

    }

    public Order(Watch watch) {
        this.watch = watch;
        this.price = watch.volumePrice;
    }

    public long getWatchId(){
        return watch.id;
    }

    public String about(){
        return "----------"+ "\n"
                + "Watch model: " + watch.model + "\n"
                + "id: " + watch.id + "\n";
    }

    public double cena() {
        return price;
    }


}
