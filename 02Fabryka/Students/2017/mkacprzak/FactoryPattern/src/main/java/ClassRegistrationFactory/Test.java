package ClassRegistrationFactory;

import java.lang.reflect.InvocationTargetException;

public class Test {

    public static void main(String[] args) throws InvocationTargetException, NoSuchMethodException, InstantiationException, IllegalAccessException {


        try {
            initClases();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
        PotionFactory potionFactory = PotionFactory.getFactory();
        Potion mp = potionFactory.createPotion("ID1");
        Potion sp = potionFactory.createPotion("ID2");
        Potion hp = potionFactory.createPotion("ID3");
        System.out.println(mp);
        System.out.println(sp);
        System.out.println(hp);

    }

    private static void initClases() throws ClassNotFoundException {

        Class.forName("ClassRegistrationFactory.HealthPotion");
        Class.forName("ClassRegistrationFactory.ManaPotion");
        Class.forName("ClassRegistrationFactory.SpeedPotion");


    }
}
