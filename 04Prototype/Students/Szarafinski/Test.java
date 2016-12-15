/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Prototyp;

/**
 *
 * @author KrzysieK
 */
public class Test {

    public static void main(String[] args) {
        System.out.println("Płytkie klonowanie");
        System.out.println(
            "--------------------------------------------------------");
        System.out.println("A) Utworzenie kopii i jej wypisanie:");
        Osoba jeden = new Osoba("Janusz", "Kowalski", "80-456", new Przedsiebiorstwo("piekarz"), new Hobby("rower"));
        wypisz(jeden,"oryginal");
        Osoba blizniak = (Osoba)jeden.KlonowaniePlytkie();
        wypisz(blizniak,"kopia");
        
        
        System.out.println("-------------------------------------");
        System.out.println("\n"+"B) Zmina danych w klonie - płytki poziom:");
        blizniak.imie = "Mikołaj";
        blizniak.nazwisko = "Golum";
        wypisz(jeden, "oryginał");
        wypisz(blizniak, "kopia");
        
        System.out.println(
            "--------------------------------------------------------");
        System.out.println("\n"+"C) Zmina danych w klonie - głęboki poziom:");
        blizniak.praca.szef.nazwa = "Kinga Mazga";
        blizniak.adres.miasto = "Wąchock";
        wypisz(jeden, "oryginał");
        wypisz(blizniak, "kopia");
        
        System.out.println("\n"+
                "Głębokie klonowanie");
        System.out.println(
            "--------------------------------------------------------");
        System.out.println("\n"+"A) Utworzenie kopii i jej wypisanie:");
        Osoba dwa = new Osoba("Daria", "MIchalczewska", "54-318", new Przedsiebiorstwo("kwiaciarka"), new Hobby("plywanie"));
        wypisz(dwa,"oryginal");
        Osoba blizniaczka = (Osoba)dwa.KlonowanieGlebokie(dwa);
        wypisz(blizniaczka,"kopia");
        
        System.out.println(
            "--------------------------------------------------------");
        System.out.println("\n"+"B) Zmina danych w klonie - płytki poziom:");
        blizniaczka.imie = "Zuzanna";
        blizniaczka.nazwisko = "Piskoń";
        wypisz(dwa, "oryginał");
        wypisz(blizniaczka, "kopia");
        
        
        System.out.println(
            "--------------------------------------------------------");
        System.out.println("\n"+ "C) Zmina danych w klonie - głęboki poziom:");
        blizniaczka.praca.szef.nazwa = "Magda Witkowska";
        blizniaczka.adres.miasto = "Łeba";
        blizniaczka.praca.stanowisko = "analityk";
        wypisz(dwa, "oryginał");
        wypisz(blizniaczka, "kopia");
        
    }

    private static void wypisz(Osoba osoba, String typ) {
        System.out.println("  " + osoba.getClass().getName() + " \"" + typ + "\":");
        System.out.println(osoba.przedstawSie());
    }
}
