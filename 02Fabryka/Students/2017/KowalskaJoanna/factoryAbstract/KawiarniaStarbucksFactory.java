package factoryAbstract;

public class KawiarniaStarbucksFactory implements KawiarniaFactory {

	public Mielenie przygotujMielenie() {
		return new DrobneMielenie();
	}
		
	public Mleko dodajMleko() {
		return new MlekoSojowe();
	}
}