package ClassRegistration.NoReflection;


import ClassRegistration.NoReflection.Products.BasketballShoes;
import ClassRegistration.NoReflection.Products.FootballShoes;
import ClassRegistration.NoReflection.Products.RunningShoes;

public class RegisterClass {


    public static void register(String idProduct) {

        NoReflectionFactory noReflectionFactory = NoReflectionFactory.getNoReflectionFactory();

        if (noReflectionFactory.m_RegisteredProducts.get(idProduct) == null) {

            switch (idProduct) {
                case ("Bieganie"):
                    noReflectionFactory.registerProduct("Bieganie", new RunningShoes());
                    break;
                case ("Koszykówka") :
                    noReflectionFactory.registerProduct("Koszykówka", new BasketballShoes());
                    break;
                case ("Piłka nożna") :
                    noReflectionFactory.registerProduct("Piłka nożna", new FootballShoes());
                    break;
            }


            }
        }
    }

