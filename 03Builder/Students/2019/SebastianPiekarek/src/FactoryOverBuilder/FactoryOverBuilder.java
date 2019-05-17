package FactoryOverBuilder;

import FactoryOverBuilder.AbstractFactory.Factories.NikeFactory;
import FactoryOverBuilder.Builder.*;


public class FactoryOverBuilder {
    public static void main(String[] args) {
        builderTime();
        abstractFactoryTime();

    }


    public static void abstractFactoryTime(){
        NikeFactory nikeFactory = NikeFactory.getNikeFactory();
        int quantity = 1_000_000_000;
        long startTime = System.nanoTime();

        for(int i = 0; i < quantity; i++) nikeFactory.orderShoes("Bieganie", 47, "czarny");

        long endTime = System.nanoTime();
        System.out.println("Abstract Factory Time : " + (endTime - startTime)/1_000_000_000.0 + " s");
    }

    public static void builderTime(){
        Director director = new Director();
        Builder runningShoesBuilder = new RunningShoesBuilder();
        director.setBuilder(runningShoesBuilder);
        int quantity = 1_000_000_000;

        long startTime = System.nanoTime();

        for(int i = 0; i < quantity; i++) director.Construct(47, "czarny");

        long endTime = System.nanoTime();
        System.out.println("Builder Time : " + (endTime - startTime)/1_000_000_000.0 + " s");
    }


}
