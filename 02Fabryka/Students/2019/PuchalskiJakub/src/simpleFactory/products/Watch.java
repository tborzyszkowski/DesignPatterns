package simpleFactory.products;

public abstract class Watch {

    protected String type;
    protected Float price;

    @Override
    public String toString() {
        return
                type + "\n" +
                        "Cost: " + price + "\n";
    }
}
