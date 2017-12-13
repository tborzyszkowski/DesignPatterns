import java.util.HashMap;
import java.util.Map;

public class TankManager {


    private Map<String,Tank> tankMap = new HashMap()
    {{

        put("T34", new Tank().turret(300)
                .engine(new Engine().power(800))
                .gun(new Gun().type("MOSQUITO").specification(new Specification().penetration(120).diameter(30))));

        put("ABRAMS", new Tank().turret(1200)
                .engine(new Engine().power(1500))
                .gun(new Gun().type("KING").specification(new Specification().penetration(150).diameter(40))));

        put("LEOPARD", new Tank().turret(1000)
                .engine(new Engine().power(1700))
                .gun(new Gun().type("DESTROYER").specification(new Specification().penetration(150).diameter(35))));
    }};

    public Tank getTankWithNewComponents(String type)
    {
        return tankMap.get(type).deepCopy();
    }
    public Tank getTankWithCommonComponents(String type)
    {
        return tankMap.get(type).shallowCopy();
    }

}
