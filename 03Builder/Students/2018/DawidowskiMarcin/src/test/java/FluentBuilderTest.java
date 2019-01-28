import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import fluentBuilder.*;

public class FluentBuilderTest {

    private CheeseBurgerBuilder cheeseBurgerBuilder;
    @Before
    public void prepare_builder() {
        this.cheeseBurgerBuilder = new CheeseBurgerBuilder();
    }


    @Test
    public void build_cheeseburger() {
        CheeseBurger builderCheese = cheeseBurgerBuilder
                .withCutlet("Beef chop")
                .withLoaf("Kaiser roll")
                .withCheese(true)
                .withTomato(false)
                .withPrice(17)
                .buildCheeseBurger();

        Assert.assertEquals("Beef chop", builderCheese.cutlet);
        Assert.assertEquals("Kaiser roll", builderCheese.loaf);
        Assert.assertEquals(true, builderCheese.cheese);
        Assert.assertEquals(false, builderCheese.tomato);
        Assert.assertEquals(17, builderCheese.price);
        System.out.println("Builder => " + builderCheese.toString());
    }
}