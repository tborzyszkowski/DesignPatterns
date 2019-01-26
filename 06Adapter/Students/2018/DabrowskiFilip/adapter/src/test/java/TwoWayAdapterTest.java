import org.junit.Assert;
import org.junit.Test;

public class TwoWayAdapterTest {

    @Test
    public void should_convert_each_measure_to_antoher_one() {

        AngloSaxonMeasures angloSaxonMeasures = new AngloSaxonMeasures(100,1000,100);
        BasicMeasures basicMeasures = new BasicMeasures(45,1143,100);

        MeasuresManager measuresManager = new MeasuresManager();

        IBasicMeasures basicMeasuresAdapter = measuresManager.createBasicMeasureAdapter(angloSaxonMeasures);
        IAngloSaxonMeasures angloSaxonMeasuresAdapter = measuresManager.createAngloSaxonMeasureAdapter(basicMeasures);

        Assert.assertEquals(angloSaxonMeasures.getWeightInPounds(), angloSaxonMeasuresAdapter.getWeightInPounds(), 0);
        Assert.assertEquals(angloSaxonMeasures.getLengthInEll(), angloSaxonMeasuresAdapter.getLengthInEll(), 0);

        Assert.assertEquals(basicMeasuresAdapter.getWeightInKilograms(), basicMeasuresAdapter.getWeightInKilograms(), 0);
        Assert.assertEquals(basicMeasuresAdapter.getLengthInMeters(), basicMeasuresAdapter.getLengthInMeters(), 0);

        Assert.assertEquals(basicMeasuresAdapter.getTimeInSeconds(), basicMeasuresAdapter.getTimeInSeconds(), 0);

    }

}
