import org.junit.Assert;
import org.junit.Test;
import simplePrototype.OrderManager;
import simplePrototype.PizzaOrder;

public class PizzaPrototypeTest {

    @Test
    public void prepareEachTeamPizza() {
        OrderManager manager = new OrderManager();
        PizzaOrder allAvailablePizzas = manager.prepareOrder();

        PizzaOrder devTeamOrder = allAvailablePizzas.clone();
        PizzaOrder qaTeamOrder = allAvailablePizzas.clone();

        Assert.assertNotEquals(allAvailablePizzas, devTeamOrder);
        Assert.assertNotEquals(allAvailablePizzas, qaTeamOrder);

        devTeamOrder.availablePizzas.remove("Hawai");
        qaTeamOrder.availablePizzas.remove("Capriciosa");

        Assert.assertNotEquals(allAvailablePizzas.availablePizzas.size(), devTeamOrder.availablePizzas.size());

        System.out.println(allAvailablePizzas.availablePizzas);
        System.out.println(devTeamOrder.availablePizzas);
        System.out.println(qaTeamOrder.availablePizzas);


    }

}
