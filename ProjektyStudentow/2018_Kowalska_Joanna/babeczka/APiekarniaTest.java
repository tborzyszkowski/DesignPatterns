package babeczka;

public class APiekarniaTest {
	
	public static void main(String[] args) {
		
		PiekarniaDomowa domowa = new PiekarniaDomowa();	
		PiekarniaSmakowita smakowita = new PiekarniaSmakowita();
					
		System.out.println("\nPrzyjęto zamówienie na 4 babeczki w cukierni Smakowita:");
		
		Babeczka babeczka1 = smakowita.zamowBabeczka("cyt");		
		Babeczka babeczka2 = smakowita.zamowBabeczka("cze");		
		Babeczka babeczka3 = smakowita.zamowBabeczka("jag");
		Babeczka babeczka4 = smakowita.zamowBabeczka("tru");
		
		Forma formaDoBabeczekSmakowita = new Forma();
		formaDoBabeczekSmakowita.dodaj(babeczka1);
		formaDoBabeczekSmakowita.dodaj(babeczka2);
		formaDoBabeczekSmakowita.dodaj(babeczka3);
		formaDoBabeczekSmakowita.dodaj(babeczka4);
		
		System.out.println("\nPrzyjęto zamówienie na 4 babeczki i 3 pączki w cukierni Domowa:");
		
		Babeczka babeczka5 = domowa.zamowBabeczka("cyt");		
		Babeczka babeczka6 = domowa.zamowBabeczka("cze");		
		Babeczka babeczka7 = domowa.zamowBabeczka("jag");		
		Babeczka babeczka8 = domowa.zamowBabeczka("tru");
			
		Forma formaDoBabeczekDomowa = new Forma();
		formaDoBabeczekDomowa.dodaj(babeczka5);
		formaDoBabeczekDomowa.dodaj(babeczka6);
		formaDoBabeczekDomowa.dodaj(babeczka7);
		formaDoBabeczekDomowa.dodaj(babeczka8);
		
		Forma blachaPaczkowDomowa = new Forma();
		Babeczka paczek1 = domowa.zamowBabeczka("pac");
		Babeczka paczek2 = domowa.zamowBabeczka("pac");
		Babeczka paczek3 = domowa.zamowBabeczka("pac");
		blachaPaczkowDomowa.dodaj(paczek1);
		blachaPaczkowDomowa.dodaj(paczek2);
		blachaPaczkowDomowa.dodaj(paczek3);
		
		formaDoBabeczekDomowa.dodaj(blachaPaczkowDomowa);
		
		System.out.println("\nKelner wita w cukierni Smakowita!");
		
		System.out.println("\nPrzyjęto kolejne zamówienie na formę 4 babeczek w cukierni Smakowita:");
		System.out.println("\nKelner przynosi zamówienie w cukierni Smakowita:");
		Kelner kelner = new Kelner();
		formaDoBabeczekSmakowita.registerObserver(kelner);
		pieczenie(formaDoBabeczekSmakowita);
		
		System.out.println("\nKelner wita w cukierni Domowa!");
		
		System.out.println("\nPrzyjęto kolejne zamówienie formę 4 babeczek i 3 pączków w cukierni Domowa:");
		System.out.println("\nKelner przynosi zamówienie w cukierni Domowa:");
		formaDoBabeczekDomowa.registerObserver(kelner);
		pieczenie(formaDoBabeczekDomowa);
		
		System.out.print("\nW sumie przygotowano i sprzedano "+BabeczkaDekorator.getLiczbaBabeczek() + " babeczek,");
		System.out.println(" w cenie "+BabeczkaDekorator.getCenaBabeczek() + " zł");		
		System.out.print("\nW sumie przygotowano i sprzedano "+PaczekDekorator.getLiczbaPaczkow() + " pączków,");
		System.out.println(" w cenie "+PaczekDekorator.getCenaPaczkow() + " zł");
		
		System.out.println("\nPrzyjęto kolejne zamówienie na 4 babeczki w cukierni Smakowita:");
		System.out.println("\nKelner w cukierni Smakowita zakończył już swoją zmianę i poszedł do domu.\n");
		
		formaDoBabeczekSmakowita.deleteObserver(kelner);
		pieczenie(formaDoBabeczekSmakowita);		
	}
	
	static void pieczenie(Babeczka babeczka) {
		babeczka.piecz();
	}
}