import java.util.HashMap;
import java.util.Map;

public class BikeManager {

    private  Map<String, Bike> prototypes = new HashMap<>();

     {
         prototypes.put("electric",
                 new Bike("electric")
                         .wheel(new Wheel(28))
                         .frame(new Frame(
                                 new Type("aluminiowa"))
                                 .size(20)));

         prototypes.put("kids",
                 new Bike("kids")
                         .wheel(new Wheel(20))
                         .frame(new Frame(
                                 new Type("stalowa"))
                                 .size(26)));

         prototypes.put("normal",
                 new Bike("normal")
                         .wheel(new Wheel(29))
                         .frame(new Frame(
                                 new Type("tytanowa"))
                                 .size(30)));
    }

    public Bike getBikePrototype(String type) {
        return prototypes.get(type).clone();
    }

    public Bike getBikeShallowCopy(String type) { return prototypes.get(type).shallowCopy(); }
}
