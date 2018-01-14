package pl.mhallman.java.builderPattern;

import org.apache.log4j.Logger;
import pl.mhallman.java.builderPattern.builder.StandardMealBuilder;
import pl.mhallman.java.builderPattern.director.Waiter;
import pl.mhallman.java.builderPattern.model.Meal;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {

        final Logger LOG = Logger.getRootLogger();


        Waiter waiter = new Waiter();
        waiter.setMealBuilder(new StandardMealBuilder());
        waiter.constructMeal();
        Meal standardMeal = waiter.getMeal();
        LOG.info(standardMeal.toString());

    }
}
