
import ClassRegistration.Reflection.ReflectionFactory;
import SimpleFactory.SimpleFactory;

import java.lang.reflect.InvocationTargetException;


public class FactoryEfficiency {

        static
        {
            try
            {
                Class.forName("ClassRegistration.Reflection.Products.RunningShoes");
            }
            catch (ClassNotFoundException any)
            {
                any.printStackTrace();
            }
        }

    private static int quantity = 1_000_000_000;
    public static void main(String[] args) throws NoSuchMethodException, InstantiationException, IllegalAccessException, InvocationTargetException {
        SimpleFactoryTime();
        MethodFactoryTime();
        AbstractFactoryTime();
        NoReflectionFactoryTime();
        ReflectionFactoryTime();
    }


    private static void SimpleFactoryTime(){
        SimpleFactory simpleFactory = SimpleFactory.getInstance();


        long startTime = System.nanoTime();
        for(int i = 0; i < quantity; i++)  simpleFactory.createShoes("Bieganie");
        long endTime = System.nanoTime();

        printTime("Simple Factory Time: ", (endTime - startTime)/1_000_000_000.0);
    }

    private static void MethodFactoryTime(){
        MethodFactory.Factories.NikeFactory nikeFactory = MethodFactory.Factories.NikeFactory.getNikeFactory();

        long startTime = System.nanoTime();
        for(int i = 0; i < quantity; i++) nikeFactory.orderShoes("Bieganie", 47, "biały");
        long endTime = System.nanoTime();

        printTime("Method Factory Time: ", (endTime - startTime)/1_000_000_000.0);
    }

    private static void AbstractFactoryTime(){
        AbstractFactory.Factories.NikeFactory nikeFactory = AbstractFactory.Factories.NikeFactory.getNikeFactory();

        long startTime = System.nanoTime();
        for(int i = 0; i < quantity; i++)  nikeFactory.orderShoes("Bieganie", 47, "biały");
        long endTime = System.nanoTime();
        printTime("Abstract Factory Time: ", (endTime - startTime)/1_000_000_000.0);
    }

    private static void NoReflectionFactoryTime(){
        ClassRegistration.NoReflection.NoReflectionFactory noReflectionFactory = ClassRegistration.NoReflection.NoReflectionFactory.getNoReflectionFactory();

        long startTime = System.nanoTime();
        for(int i = 0; i < quantity; i++)  noReflectionFactory.createShoes("Bieganie");
        long endTime = System.nanoTime();

        printTime("No Reflection Factory Time: ", (endTime - startTime)/1_000_000_000.0);
    }

    private static void ReflectionFactoryTime() throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {
        ReflectionFactory reflectionFactory = ReflectionFactory.getReflectionFactory();

        long startTime = System.nanoTime();
        for(int i = 0; i < quantity; i++) reflectionFactory.createProduct("Bieganie");
        long endTime = System.nanoTime();

        printTime("Reflection Factory Time: ", (endTime - startTime)/1_000_000_000.0);

    }

    private static void printTime(String str, double time){
        System.out.println(str + time + " s");
    }


}
