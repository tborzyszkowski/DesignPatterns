package FactoryMethod;

public class NissanFactory extends CarFactoryMethod {
    Car getCar(String model){
       if (model.equals("GT-R")){
           return new NissanGTR();
       } else if (model.equals("350Z")){
           return new Nissan350();
       } else return null;
    }
}
