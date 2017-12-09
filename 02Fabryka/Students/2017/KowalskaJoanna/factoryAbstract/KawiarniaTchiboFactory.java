package factoryAbstract;

public class KawiarniaTchiboFactory implements KawiarniaFactory {

	public Mielenie przygotujMielenie() {
		return new SrednieMielenie();
	}
	
	public Mleko dodajMleko() {
		return new MlekoKokosowe();
	}
}