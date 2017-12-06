package SimpleFactory;

public class PotionFactory {


    public Potion createPotion(String type) {

        Potion potion = null;

        if (type.equals("mana")) {
            potion = new ManaPotion();
        } else if (type.equals("health")) {
            potion = new HealthPotion();
        } else if (type.equals("speed")) {
            potion = new SpeedPotion();
        } else if (type.equals("mysterious")) {
            potion = new MysteriousPotion();
        }
        return potion;
    }


}
