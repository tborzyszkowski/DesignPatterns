package babeczka;

public class PiekarniaDomowa extends Piekarnia {

	@Override
	protected Babeczka przygotujBabeczka(String type) {
		Babeczka babeczka = null;
		PiekarniaFactory factory = new PiekarniaDomowaFactory();
		
		if ("cyt".equalsIgnoreCase(type)) {			  
			babeczka = new BabeczkaDekorator(new BabeczkaCytrynowa(factory));
			System.out.println("Babeczka cytrynowa w stylu Domowym:");
		} else if ("cze".equalsIgnoreCase(type)) { 
			babeczka = new BabeczkaDekorator(new BabeczkaCzekoladowa(factory));
			System.out.println("Babeczka czekoladowa w stylu Domowym:");
		} else if ("jag".equalsIgnoreCase(type)) { 
			babeczka = new BabeczkaDekorator(new BabeczkaJagodowa(factory));
			System.out.println("Babeczka jagodowa w stylu Domowym:");
		} else if ("tru".equalsIgnoreCase(type)) { 
			babeczka = new BabeczkaDekorator(new BabeczkaTruskawkowa(factory));
			System.out.println("Babeczka truskawkowa w stylu Domowym:");
		} else if ("pac".equalsIgnoreCase(type)) { 
			babeczka = new PaczekDekorator(new PaczekAdapter(new Paczek(factory)));
			System.out.println("Pączek w stylu Domowym:");
		} 
		return babeczka;
	}
}
