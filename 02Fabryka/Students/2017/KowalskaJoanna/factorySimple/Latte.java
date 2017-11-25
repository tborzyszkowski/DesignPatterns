package factorySimple;

public class Latte implements Kawa {

	@Override
	public void cena() {
		System.out.println("Kawa Latte kosztuje 6 zł.");
	}
	
	@Override
	public void wielkosc() {
		System.out.println("Filiżanka Latte ma 200 ml.");
	}

	@Override
	public void ileKawy() {
		System.out.println("Latte zawiera 25 ml. kawy.");
	}

	@Override
	public void ileMleka() {
		System.out.println("Spienione mleko w Latte ma 175 ml objętości.");
	}
}
