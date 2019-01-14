package zad2;

import zad2.brand.BrandName;
import zad2.carType.Type;
import zad2.engine.Engine;


public class Car implements Cloneable {

    private BrandName brandName;
    private Engine engine;
    private Type type;

    public Car(BrandName brandName, Engine engine, Type type){
        this.brandName = brandName;
        this.engine = engine;
        this.type = type;
    }

    public Car clone(){
        return new Car(this.brandName, this.engine.clone(), this.type.clone());
    }

    public BrandName getBrandName(){
        return brandName;
    }

    public Engine getEngine(){
        return engine;
    }

    public Type getType(){
        return type;
    }

    public void setBrandName(BrandName brandName){
        this.brandName = brandName;
    }

    public void setEngine(Engine engine){
        this.engine = engine;
    }

    public void setType(Type type){
        this.type = type;
    }

    @Override
    public String toString() {
        return "Car{" +
                "Brand = " + brandName +
                ", engine = " + engine.toString() +
                ", type = " + type.toString() + '}';
    }
}
