package ClassRegistration.Reflection;


import ClassRegistration.Reflection.Products.Shoes;
import org.junit.jupiter.api.Test;
import java.lang.reflect.InvocationTargetException;

class ReflectionFactoryTest {

    static
    {
        try
        {
            Class.forName("ClassRegistration.Reflection.Products.RunningShoes");
            Class.forName("ClassRegistration.Reflection.Products.FootballShoes");
            Class.forName("ClassRegistration.Reflection.Products.BasketballShoes");
        }
        catch (ClassNotFoundException any)
        {
            any.printStackTrace();
        }
    }

    @Test
    void TestReflectionFactory() throws  InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        Shoes shoes;
        ReflectionFactory reflectionFactory = ReflectionFactory.getReflectionFactory();

        shoes = reflectionFactory.createProduct("Bieganie");
        System.out.println(shoes.description());

        shoes = reflectionFactory.createProduct("Koszykówka");
        System.out.println(shoes.description());

        shoes = reflectionFactory.createProduct("Piłka nożna");
        System.out.println(shoes.description());
    }

}