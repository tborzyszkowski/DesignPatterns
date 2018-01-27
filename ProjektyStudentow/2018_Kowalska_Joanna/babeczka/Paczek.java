package babeczka;

public class Paczek {
	
	PiekarniaFactory factory;
	 
	public Paczek(PiekarniaFactory factory) {
		this.factory = factory;
	}
	
	void przygotuj() {
	}	
	
	public void smaz() {
		System.out.println("KUCHARZ:\nPączek usmażony!");
	}
	
	@Override
	public String toString() {
		return "pączek";
	}	
}
