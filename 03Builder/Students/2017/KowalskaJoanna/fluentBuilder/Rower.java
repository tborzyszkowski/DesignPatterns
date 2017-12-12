package fluentBuilder;

public class Rower {
	private String typ;
	private int opony;
	private String kierownica;
	private int przerzutka;
	
	private Rower(final Builder builder) {
        this.typ = builder.typ;
        this.opony = builder.opony;
        this.kierownica = builder.kierownica;
        this.przerzutka = builder.przerzutka;
    }
	
	public String getTyp() {
		return typ;
	}
	
	public int getOpony() {
		return opony;
	}
		
	public String getKierownica() {
		return kierownica;
	}
		
	public int getPrzerzutka() {
		return przerzutka;
	}
		
    public static class Builder {
    	private final String typ;
    	private int opony;
    	private String kierownica;
    	private int przerzutka;
    	 
    	public Builder(final String typ) {
            this.typ = typ;
        }
    	 
    	public Builder opony(final int opony) {
            this.opony = opony;
            return this;
        }
      
    	public Builder kierownica(final String kierownica) {
            this.kierownica = kierownica;
            return this;
        }
    	
    	public Builder przerzutka(final int przerzutka) {
            this.przerzutka = przerzutka;
            return this;
        }
        
        public Rower build() { 
            return new Rower(this);
        } 
    }

	@Override
	public String toString() {
		return "Typ roweru: " + typ + "\nTyp opon: " + opony + "\nTyp kierownicy: " + kierownica + "\nTyp przerzutki: " + przerzutka + "\n";
	}	
}
