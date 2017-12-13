package factoryAbstract;

public abstract class Kawa {	
	Mielenie mielenie;
	Mleko mleko;
			
	public void cena() {
		System.out.println("Cena kawy");
	}
	
	public void wielkosc() {
		System.out.println("Wielkość kawy");
	}
	
	public void ileKawy() {
		System.out.println("Ile kawy");
	}  
	
	public void ileMleka() {
		System.out.println("Ile mleka");
	}
	
	abstract void przygotuj();
}
