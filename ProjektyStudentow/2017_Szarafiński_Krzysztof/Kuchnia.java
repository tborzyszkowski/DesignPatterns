/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author KrzysieK
 */
public class Kuchnia {

    public void przygotuj(String potrawa) {

    }

    public void zawolajKucharza() {
        System.out.println("[Bhadramurti]\n"
                + "DZYŃ DZYŃ KUCHARZU JEST ZAMÓWIENIE, PRZYJDŹ!\n"
                + "[Kucharz]\n"
                + "Cześć Bhadramurti, już jestem!");
    }

    public void zawolajKucharza(String danie, Date dnia) {
        SimpleDateFormat data = new SimpleDateFormat("yyyyy-mm-dd");
        System.out.println("[Kucharz]\n"
                + "Bhadramurti, co to oferta dnia? Dziś, czyli " + generujDate(dnia) + " umiem tylko zrobić kotlet z ziemniakami. "
                + "Mam zrobić?");
    }

    public Boolean zlecPrzygotowanie(String potrawa) {
        System.out.println("Niestety nie umiem przyrządzić " + potrawa + ".\n"
                + "To wygląda na skomplikowane zamówienie. Przekaż że się właśnie skończyło.");
        return false;
    }

    // budowniczy
    public Danie zamow(zestawObiadowy budowniczy) {
        Danie danie = budowniczy.noweDanie();
        danie.przygotuj();
        System.out.println("[po 15 minutach]");
        danie.wydaj();
        return danie;
    }

    public void zamow(String opis) {
        System.out.println("[Kucharz]\n"
                + "Umiem tylko gotować dzisiaj ziemniaki, kawy nie umiem zrobić. To tylko Ludomir potrafi.");
    }

    public Kawa zrobKawe(int liczba) {
        if (liczba == 1) {
            return new KawaZCukrem(new KawaZmlekiem(new KawaCzarna()));
        } else {
            return new KawaZCukrem(new KawaEspresso());
        }
    }

    public String generujDate(Date dzien) {
        SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy");
        return format.format(dzien.getTime());
    }

}
