package Dekorator;

/**
 * Created by Karkucinski Krzysztof on 2016-12-10.
 */
public class Zamowienie {
    public static void main   (String []args){
        Jedzenie zamowienie1 = new Cheeseburger();
        System.out.printf("Cena za: %s wynosi: %.2f\n",zamowienie1.dodajOpis(),zamowienie1.cena() );

        Jedzenie zamowienie2 = new Cheeseburger();
        zamowienie2 = new Ser(zamowienie2);
        zamowienie2 = new Salata(zamowienie2);
        zamowienie2 = new Cebula(zamowienie2);
        System.out.printf("Cena za: %s wynosi: %.2f\n",zamowienie2.dodajOpis(),zamowienie2.cena() );

        Jedzenie zamowienie3 = new Hotdog();
        zamowienie3 = new Ser(zamowienie3);
        zamowienie3 = new Salata(zamowienie3);
        zamowienie3 = new Salata(zamowienie3);
        System.out.printf("Cena za: %s wynosi: %.2f\n",zamowienie3.dodajOpis(),zamowienie3.cena() );
    }
}
