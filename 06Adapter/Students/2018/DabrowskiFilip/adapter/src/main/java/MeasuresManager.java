public class MeasuresManager {

    public TwoWayMeasureAdapter createBasicMeasureAdapter(AngloSaxonMeasures angloSaxonMeasures) {
        return new TwoWayMeasureAdapter(
                MeasureType.ANG_SAX,
                angloSaxonMeasures.getWeightInPounds(),
                angloSaxonMeasures.getLengthInEll(),
                angloSaxonMeasures.getTimeInSeconds()
        );
    }

    public TwoWayMeasureAdapter createAngloSaxonMeasureAdapter(BasicMeasures basicMeasures) {
        return new TwoWayMeasureAdapter(
                MeasureType.BASIC,
                basicMeasures.getWeightInKilograms(),
                basicMeasures.getLengthInMeters(),
                basicMeasures.getTimeInSeconds()
        );
    }
}
