package pl.mhallman.java.fluentBuilderPattern;

import org.apache.log4j.Logger;
import pl.mhallman.java.fluentBuilderPattern.model.Meal;

import java.text.MessageFormat;

import static java.text.MessageFormat.format;

/**
 * Hello world!
 *
 */
public class App 
{

    public static final String PATTERN = "{0} {1}";

    public static void main(String[] args ) {

        Logger LOG = Logger.getRootLogger();

        Meal standardowyObiad = new Meal
                .Builder("Obiad rodzinny na 4 osoby")
                .mainCourse("Schabowy z ziemniakami i surówką", 4)
                .dessert("Lody", 3)
                .build();

        Meal wypasionyObiad = new Meal
                .Builder("Wypasiony obiad na 6 osób")
                .appetizer("Krewetki i paluszki krabowe", 3)
                .mainCourse("Stek Ribeye", 6)
                .dessert("Tiramisu", 6)
                .build();

        LOG.info(format(PATTERN, ">>>>Standardowy obiad", standardowyObiad.toString()));
        LOG.info(format(PATTERN, ">>>>Wypasiony obiad", wypasionyObiad.toString()));


    }
}
