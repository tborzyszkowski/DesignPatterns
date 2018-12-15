package FactoryMethod;

public class KIAFactory extends CarFactoryMethod{
    Car getCar(String model){
        if (model.equals("Stinger")){
            return new KIAStinger();
        } else if (model.equals("Ceed")){
            return new KIACeed();
        } else return null;
    }
}
