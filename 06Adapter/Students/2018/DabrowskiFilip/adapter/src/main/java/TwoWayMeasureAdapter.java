public class TwoWayMeasureAdapter implements IAngloSaxonMeasures, IBasicMeasures {

    private IBasicMeasures basicMeasures;

    private IAngloSaxonMeasures angloSaxonMeasures;

    private MeasureType measureType;

    public TwoWayMeasureAdapter(MeasureType measureType, double weight, double length, double time) {
        super();
        this.measureType = measureType;
        if(this.measureType == MeasureType.ANG_SAX) {
            this.angloSaxonMeasures = new AngloSaxonMeasures(weight, length, time);
            this.basicMeasures = null;
        } else if (this.measureType == MeasureType.BASIC) {
            this.basicMeasures = new BasicMeasures(weight, length, time);
            this.angloSaxonMeasures = null;
        }
    }

    public double getWeightInPounds() {
        if(this.measureType == MeasureType.BASIC){
            return this.basicMeasures.getWeightInKilograms() / 0.45;
        } else return 0;
    }

    public double getLengthInEll() {
        if(this.measureType == MeasureType.BASIC){
            return this.basicMeasures.getLengthInMeters() / 1.143;
        } else return 0;

    }

    public double getTimeInSeconds() {
        if(this.measureType == MeasureType.ANG_SAX){
            return angloSaxonMeasures.getTimeInSeconds();
        } else if (this.measureType == MeasureType.BASIC) {
            return basicMeasures.getTimeInSeconds();
        } else return 0;

    }

    public double getWeightInKilograms() {
        if(this.measureType == MeasureType.ANG_SAX){
            return this.angloSaxonMeasures.getWeightInPounds() * 0.45;
        } else return 0;
    }

    public double getLengthInMeters() {
        if(this.measureType == MeasureType.ANG_SAX){
            return this.angloSaxonMeasures.getLengthInEll() * 1.143;
        } else return 0;
    }
}
