package zad2;

public class HealthCard implements I_HealthCard {

    private String name;
    private double height;
    private double weight;

    public HealthCard(String name, double height, double weight) {
        this.name = name;
        this.height = height;
        this.weight = weight;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public double getHeightInInches() {
        return height;
    }

    @Override
    public double getWeightInPounds() {
        return weight;
    }

    @Override
    public void display() {
        System.out.println(
                "HEALTH CARD" + "\n"
                + "Name: " + name + "\n"
                + "Height: " + height + "\n"
                + "Weight: " + weight
        );
    }

}
