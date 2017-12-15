package builder;

public class Kierownica {
	private String typ;

	public String getTyp() {
		return typ;
	}

	public void setTyp(String typ) {
		this.typ = typ;
	}

	@Override
	public String toString() {
		return "Typ kierownicy: " + typ + "\n";
	}	
}
