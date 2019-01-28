import org.junit.Assert;
import org.junit.Test;
import zad1.BurgerMenu;
import zad1.OrderManager;

public class Zad1Test {

    @Test
    public void get_orders() {
        OrderManager manager = new OrderManager();

        BurgerMenu availableBurgers = manager.prepareOrder();
        BurgerMenu clonedOrder1 = availableBurgers.clone();
        BurgerMenu clonedOrder2 = availableBurgers.clone();

        Assert.assertNotEquals(availableBurgers, clonedOrder1);
        Assert.assertNotEquals(availableBurgers, clonedOrder2);

        clonedOrder1.burgers.remove("Fish Burger");
        clonedOrder2.burgers.remove("Veggie Burger");

        Assert.assertNotEquals(availableBurgers.burgers, clonedOrder1.burgers);
        Assert.assertNotEquals(availableBurgers.burgers, clonedOrder2.burgers);
        Assert.assertNotEquals(clonedOrder1.burgers, clonedOrder2.burgers);

        System.out.println("All available Burgers => " + availableBurgers.burgers);
        System.out.println("Burgers from order 1 => " + clonedOrder1.burgers);
        System.out.println("Burgers from order 2 => " + clonedOrder2.burgers);


    }

}
