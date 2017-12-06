package builder;

public class Rower {
	private Opony opony;
	private Kierownica kierownica;
	private Przerzutka przerzutka;
	
	public Opony getOpony() {
		return opony;
	}
	public void setOpony(Opony opony) {
		this.opony = opony;
	}
	
	public Kierownica getKierownica() {
		return kierownica;
	}
	public void setKierownica(Kierownica kierownica) {
		this.kierownica = kierownica;
	}
	
	public Przerzutka getPrzerzutka() {
		return przerzutka;
	}
	public void setPrzerzutka(Przerzutka przerzutka) {
		this.przerzutka = przerzutka;
	}
	
	@Override
	public String toString() {
		return opony + "" + kierownica + "" + przerzutka;
	}	
}
