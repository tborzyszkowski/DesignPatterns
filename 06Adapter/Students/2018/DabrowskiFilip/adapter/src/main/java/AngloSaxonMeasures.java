public class AngloSaxonMeasures implements IAngloSaxonMeasures {

    private double weight;

    private double length;

    private double time;

    public AngloSaxonMeasures(double weight, double length, double time) {
        this.weight = weight;
        this.length = length;
        this.time = time;
    }

    public double getWeightInPounds() {
        return weight;
    }

    public double getLengthInEll() {
        return length;
    }

    public double getTimeInSeconds() {
        return time;
    }
}
