import shop.Order;
import watchModels.WatchModels;
import shop.Shop;

public class AppMain {
    public static void main(String[] args) throws CloneNotSupportedException {

        Shop shop = new Shop();

        System.out.println("-------------------------------");

        shop.start(10000);

        shop.stanKonta();

        System.out.println("-----------------------------------");

        shop.orderWatch(WatchModels.C1,1);
        shop.orderWatch(WatchModels.S1, 2);

        shop.showStoreDetails();
//        shop.showStore();

        shop.stanKonta();

        System.out.println("--------------------------------------");

        Order order = shop.prepareSell(WatchModels.C1,800,false,false);
        Order order1 = shop.prepareSell(WatchModels.S1,600,true,true);


        shop.sell(order);
        shop.sell(order1);

        System.out.println("----------------------------------------");

        shop.showStoreDetails();
//        shop.showStore();

        System.out.println("----------------------------------------");
        shop.stanKonta();



    }
}
