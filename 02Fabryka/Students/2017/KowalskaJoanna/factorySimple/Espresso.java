package factorySimple;

public class Espresso implements Kawa {

	@Override
	public void cena() {
		System.out.println("Espresso kosztuje 4 zł.");
	}
	
	@Override
	public void wielkosc() {
		System.out.println("Filiżanka Espresso ma 30 ml.");
	}

	@Override
	public void ileKawy() {
		System.out.println("Espresso zawiera 30 ml. kawy.");		
	}

	@Override
	public void ileMleka() {
		System.out.println("W kawie Espresso nie ma mleka.");
	}
}
