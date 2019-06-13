package shop;

import decorator.AdditionalStrap;
import decorator.LimitedBox;
import decorator.Margin;
import watchModels.Watch;
import watchModels.WatchModels;
import factory.WatchPrototypeManager;

import java.util.ArrayList;

public class Shop {

    private WatchPrototypeManager watchPrototypeManager;
    private Store store;
    private double stanKonta;


    public Shop() {

        store = Store.getInstance();
        watchPrototypeManager = new WatchPrototypeManager();

    }

    public void start(double budget) throws CloneNotSupportedException {
        watchPrototypeManager.loadWatches();
        stanKonta = budget;
    }

    public void stanKonta() {
        System.out.println("STAN KONTA: " + stanKonta);
    }

    public void showStore() {

        store.showStore();

    }

    public void showStoreDetails(){

        store.showStoreDetails();

    }

    public void orderWatch(WatchModels watchModel, int amount) throws CloneNotSupportedException {

        ArrayList<Watch> watchOrder = new ArrayList<>();
        Watch watchType = watchPrototypeManager.getWatch(watchModel);

        for (int i = 0; i < amount; i++){

            watchOrder.add((Watch) watchType.clone());
            stanKonta = stanKonta - watchType.volumePrice;

        }

        store.addWatch(watchOrder);

    }


    public Order prepareSell(WatchModels watchModel, double margin, boolean additionalStrap, boolean limitedBox){
        Watch watch = store.getWatch(watchModel);
        Order order = new Order(watch);
        if (additionalStrap == true)
            order = new AdditionalStrap(order);
        if (limitedBox == true){
            order = new LimitedBox(order);
        }
        order = new Margin(order, margin);
        return order;
    }

    public void sell(Order order){
        System.out.println("Sprzedano: " + order.about());
        stanKonta = stanKonta + order.cena();
        store.removeFromMagazine(order.getWatchId());

    }

}
