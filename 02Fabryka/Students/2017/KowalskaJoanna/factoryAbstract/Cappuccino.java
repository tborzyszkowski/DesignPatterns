package factoryAbstract;

public class Cappuccino extends Kawa {
	
	KawiarniaFactory factory;
	 
	public Cappuccino(KawiarniaFactory factory) {
		this.factory = factory;
	}
	
	@Override
	public void cena() {
		System.out.println("Cappucino kosztuje 5 zł.");
	}
	
	@Override
	public void wielkosc() {
		System.out.println("Filiżanka Cappuccino ma 150 ml.");
	}

	@Override
	public void ileKawy() {
		System.out.println("Cappuccino zawiera 25 ml. kawy.");
	}

	@Override
	public void ileMleka() {
		System.out.println("Spienione mleko w Cappuccino ma 125 ml objętości.");
	}
		
	@Override
	void przygotuj() {
		mielenie = factory.przygotujMielenie();
		mleko = factory.dodajMleko();
	}

	public String toString() {
		String info = " Rodzaj mielenia kawy:\n" + mielenie + "\n Rodzaj mleka:\n" + mleko + "\n";
		return info;
	}
}
