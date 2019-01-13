public class BasicMeasures implements  IBasicMeasures {

    private double weight;

    private double length;

    private double time;

    public BasicMeasures(double weight, double length, double time) {
        this.weight = weight;
        this.length = length;
        this.time = time;
    }

    public double getWeightInKilograms() {
        return weight;
    }

    public double getLengthInMeters() {
        return length;
    }

    public double getTimeInSeconds() {
        return time;
    }
}
