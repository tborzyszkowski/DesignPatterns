package FactoryOverBuilder.Builder;

public class Main {

    public static void main(String[] args) {

        Director director = new Director();


        Builder runningShoesBuilder = new RunningShoesBuilder();
        director.setBuilder(runningShoesBuilder);
        director.Construct(47, "czarny");

        Product runningShoes = runningShoesBuilder.getShoes();
        System.out.println(runningShoes);


    }
}
