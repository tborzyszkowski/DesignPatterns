package BuilderOverFactory.Builder;


public class Director {
    private Builder builder;

    public void setBuilder(Builder builder){
        this.builder = builder;
    }

//    public Document getZestaw(){
//        return builder.getShoes();
//    }

    public void Construct(int size, String color, int price) {
        builder.newProduct();
//        builder.checkSize(size);
//        builder.buildShoes(color, price);
        builder.setSize(size);
        builder.setFabric(color);
        builder.setSole(price);
        builder.setTie(price);
        builder.setName();
    }
}
