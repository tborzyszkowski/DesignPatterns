/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

import java.util.Date;
import java.util.Scanner;

/**
 *
 * @author KrzysieK
 */
public class COOL_RESTAURANT extends Bajka {

    public COOL_RESTAURANT(String lektor) {
        this.lektor = lektor;
    }

    @Override
    public void czytaj() {
        wstep();
        StringBuilder display = new StringBuilder();
        display.append("[Acyutananda]\n");
        display.append("Dzień dobry,\nNazywam się Acyutananda, po Indyjsku znaczy ten który nigdy nie upada(nie poddaje się).\n");
        display.append("Jesteś w najlepszej restauracji w Twym życiu. Z wielką radością witam Cidbie w COOL RESTAURANT!");
        System.out.println(display.toString() + "\n");
        display.setLength(0);
        System.out.print("[Narrator]\n"
                + "Przedstaw sie podajac swoje Imie: ");
        Scanner in = new Scanner(System.in);
        String imie = in.nextLine();
        // singleton
        Klient klient = Klient.instancja(imie);
        System.out.println();
        display.append("[Acyutananda]\n");
        display.append("Kliencie " + klient.getImie() + ",");
        display.append("\nprosze rozgladnij się po naszym wybornym MENU. Wybierz co zechciał byś skonsumować z przyjemnością.");
        display.append("\nPoniżej znajdziesz zestaw wyśmienitych potraw oraz dodatkow. Wybierz te które będą rozkoszować Twe podniebienie:");
        System.out.println(display.toString());
        display.setLength(0);
        Recepcja recepcja = new Recepcja();
        Menu menu = new Menu();
        for (int i = 0; i < menu.getMenu().size(); i++) {
            System.out.println("[" + (i + 1) + "] " + menu.getMenu().get(i));
        }
        int licznik = 1;
        Boolean przywitacSie = true;
        // fasada
        do {
            System.out.print("\n"
                    + "[Narrator]\n"
                    + "Wybierz numer pozycji z menu (podaj cyfrę): ");
            String wybor = in.nextLine();
            if (wybor.isEmpty() || !isNumeric(wybor)) {
                System.out.println("\n[Acyutananda]\n"
                        + "Przykro mi że nic Ciebie nie zainteresowało");
            } else if (Integer.valueOf(wybor) < 9 && Integer.valueOf(wybor) > 0) {
                System.out.println("[Acyutananda]\n"
                        + "Gratuluję wyboru! Już idę do recepcji zamówić.");
                if (przywitacSie) {
                    recepcja.przywitanie(menu.getMenu().get(Integer.valueOf(wybor) - 1));
                    przywitacSie = false;
                }
                Boolean rezultat = recepcja.zamow(menu.getMenu().get(Integer.valueOf(wybor) - 1));
                if (!rezultat) {
                    System.out.println("[Acyutananda do " + klient.getImie() + "]\n"
                            + "Niestety akurat to się skończyło.");
                }
            } else {
                System.out.println("Podałeś błedną pozycję, proszę skup się i wybierz poprawnie. ");
            }
        } while (licznik++ < 4);

        System.out.println();
        display.append("[Acyutananda]\nDrogi kliencie ").append(klient.getImie()).append(",\n");
        display.append("Z przykrością muszę stwierdzić, że niestety wszystko co chciałeś zamówić się skończyło,");
        display.append("tego nie ma albo nic Ciebie nie zainteresowało.\n");
        display.append("Zapytam kolejny raz koleżankę Bhadramurti, co po Indyjsku znaczy: ucieleśnienie dobra");
        display.append(" i życzliwości, czy możemy zaoferować coś extra dla Ciebie.");
        System.out.println(display.toString());
        display.setLength(0);
        Date dzisiaj = new Date();
        // budowniczy
        Danie obiad = recepcja.zamow("Danie dnia", dzisiaj);
        display.append("[Acyutananda do ").append(klient.getImie()).append("]\n");
        display.append("Mamy w ofercie DANIE DNIA: ").append(obiad.toString()).append(", a jego centa to: ").append(obiad.cena).append("PLN\n");
        display.append("Tak długo czekałeś, mam nadzieję że będzie smakować! Smacznego!");
        display.append("\n...[po trochu chwili]...\n");
        display.append("Drogi kliencie ").append(klient.getImie()).append(",\n");
        display.append("W ramach przeprosin chcę zaoferować kawę. Jakiej byś się napił?");
        System.out.println(display.toString());
        display.setLength(0);
        System.out.println("[Narrator]\n"
                + "Proszę napisz jaką chcesz kawę: ");
        String opis = in.nextLine();
        System.out.println("\n[Acyutananda]\nDziękuję, już biegnę zamówić ją dla Ciebie serdeczny mój kliencie.");
        // dekorator
        Kawa kawa = recepcja.zamowKawe(opis);
        System.out.println("[Acyutananda do " + klient.getImie() + "]\n"
                + "Najsłodszy Kliencie " + klient.getImie() + ",\n"
                + "Jak wspomniałem w ramach przeprosin chcę zaoferować kawę. Proszę oto Twoja kawa: " + kawa.getNazwa());
        System.out.println("...[po trochu chwili]...");
        System.out.println("Najwspanialszy kliencie " + klient.getImie() + ",\n"
                + "Czy życzysz sobie coś jeszcze?\n"
                + "Nie musisz odpowiadać. Wiem, że chcesz jeszcze deser do przepysznej kawy. Zaraz przyniosę!");

        // dekorator oraz fabryka
        Deser deserDoKawy = recepcja.zamowDeser("do Kawy");
        Kawa kawaDoDeseru = recepcja.kawaDoDeseru(opis);
        System.out.println("[Acyutananda do " + klient.getImie() + "]\n"
                + "Najsłodszy Kliencie " + klient.getImie() + ",\n"
                + "Proszę oto Twoja druga kawa: " + kawaDoDeseru.getNazwa() + " oraz deser: " + deserDoKawy.getNazwa());
        System.out.println("...[po trochu chwili]...");
        display.setLength(0);
        display.append("Teraz możesz już iść. Wiem że masz inne srpawy jeszcze do załatwienia, ale wpierw jeszcze zapłać!\n");
        display.append("Łącznie będzie to: ").append(obiad.cena + kawa.cena() + kawaDoDeseru.cena() + deserDoKawy.getCena()).append("PLN\n");
        display.append("za wszystko zapłacisz u nas kartą wiadomo jaką.\n");
        display.append("Oczywiście nie myśl sobie że w tej cenie jest opłata za:\n");
        display.append(kawa.getNazwa()).append(" w cenie: ").append(kawa.cena()).append("PLN oraz\n");
        display.append(kawaDoDeseru.getNazwa()).append(" w cenie: ").append(kawaDoDeseru.cena()).append("PLN.\n");
        display.append("Za deser ").append(deserDoKawy.getNazwa()).append(" w cenie: ").append(deserDoKawy.getCena()).append("PLN też nie policzyłem Ciebie.\n");
        display.append("U nas wszystko jest za darmo!\n\n");
        display.append("Dziękuję w swoim imieniu jak i naszego całego zespołu.\n"
                + "DO ZOBACZENIA następnym razem w COOL RESTAURANT wspaniałomyślny ");
        display.append("kliencie ").append(klient.getImie());
        System.out.println(display.toString());

    }

    private void wstep() {
        System.out.println("-----------  Czyta dla Państwa: " + lektor + ".  -----------\n\n");
    }

    public static boolean isNumeric(String str) {
        try {
            double d = Double.parseDouble(str);
        } catch (NumberFormatException blad) {
            return false;
        }
        return true;
    }
}
