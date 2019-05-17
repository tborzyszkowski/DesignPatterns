package pluggableAdapter;

public class Adaptee {
	public String convert(double pln, double eur, int precise) {
		Double d = 100.d / 4.6;
		return (d).toString().substring(0, 3 + precise);
	}
}
