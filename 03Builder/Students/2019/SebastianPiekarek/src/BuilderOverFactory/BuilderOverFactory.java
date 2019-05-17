package BuilderOverFactory;


import BuilderOverFactory.AbstractFactory.Factories.NikeFactory;
import BuilderOverFactory.Builder.Director;
import BuilderOverFactory.Builder.*;
import BuilderOverFactory.Builder.RunningShoesBuilder;
import BuilderOverFactory.FluentBuilder.ProductBuilder;

public class BuilderOverFactory {
    public static void main(String[] args) {
        fluentBuilderTime();
        abstractFactoryTime();
        builderTime();
    }


    public static void abstractFactoryTime(){
        NikeFactory nikeFactory = NikeFactory.getNikeFactory();
        int quantity = 1_000_000_000;
        long startTime = System.nanoTime();

        for(int i = 0; i < quantity; i++) nikeFactory.orderShoes("Piłka nożna", 40, "czerwony",1200);

        long endTime = System.nanoTime();
        System.out.println("Abstract Factory Time : " + (endTime - startTime)/1_000_000_000.0);
    }

    public static void builderTime(){
        Director director = new Director();
        Builder runningShoesBuilder = new RunningShoesBuilder();
        director.setBuilder(runningShoesBuilder);
        int quantity = 1_000_000_000;


        long startTime = System.nanoTime();

        for(int i = 0; i < quantity; i++) director.Construct(40, "czerwony", 1200);

        long endTime = System.nanoTime();
        System.out.println("Builder Time : " + (endTime - startTime)/1_000_000_000.0);
    }

    public static void fluentBuilderTime(){

        int quantity = 1_000_000_000;

        long startTime = System.nanoTime();

        for(int i = 0; i < quantity; i++){
            new ProductBuilder()
                    .setBrand("NIKE")
                    .setSize(47)
                    .setName("Predator")
                    .setFabric("tekstylia")
                    .setSole(4799)
                    .setTie(4799)
                    .build();
        }

        long endTime = System.nanoTime();
        System.out.println("Fluent Builder Time : " + (endTime - startTime)/1_000_000_000.0);
    }


}
