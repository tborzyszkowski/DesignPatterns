package babeczka;

public class PiekarniaSmakowita extends Piekarnia {

	@Override
	protected Babeczka przygotujBabeczka(String type) {
		Babeczka babeczka = null;
		PiekarniaFactory factory = new PiekarniaSmakowitaFactory();
		
		if ("cyt".equalsIgnoreCase(type)) {			  
			babeczka = new BabeczkaDekorator(new BabeczkaCytrynowa(factory));
			System.out.println("Babeczka cytrynowa w stylu Smakowita:");
		} else if ("cze".equalsIgnoreCase(type)) { 
			babeczka = new BabeczkaDekorator(new BabeczkaCzekoladowa(factory));
			System.out.println("Babeczka czekoladowa w stylu Smakowita:");
		} else if ("jag".equalsIgnoreCase(type)) { 
			babeczka = new BabeczkaDekorator(new BabeczkaJagodowa(factory));
			System.out.println("Babeczka jagodowa w stylu Smakowita:");
		} else if ("tru".equalsIgnoreCase(type)) { 
			babeczka = new BabeczkaDekorator(new BabeczkaTruskawkowa(factory));
			System.out.println("Babeczka truskawkowa w stylu Smakowita:");
		} else if ("pac".equalsIgnoreCase(type)) { 
			babeczka = new BabeczkaDekorator(new PaczekAdapter(new Paczek(factory)));
			System.out.println("Pączek w stylu Smakowita:");
		} 
		return babeczka;
	}
}
