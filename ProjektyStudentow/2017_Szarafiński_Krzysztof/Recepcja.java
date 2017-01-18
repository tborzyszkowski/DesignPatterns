/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

import java.util.Date;

/**
 *
 * @author KrzysieK
 */
public class Recepcja {

    public Recepcja() {
        this.kuchnia = new Kuchnia();
        this.baza = new BazaPracownikow();
        this.kadry = new Kadry();
        this.magazyn = new Magazyn();
        this.cukiernia = Cukiernia.instancja();
    }
    BazaPracownikow baza;
    Kuchnia kuchnia;
    Kadry kadry;
    Magazyn magazyn;
    Cukiernia cukiernia;

    Danie obiad = null;

    public Danie zamow(String danie, Date data) {
        kuchnia.zawolajKucharza(danie, data);
        System.out.println("[Bhadramurti]\n"
                + "Koniecznie! nie możemy klienta zostawić głodnego!");
        return kuchnia.zamow(new DanieDnia());
    }

    public Boolean zamow(String potrawa) {
        kuchnia.zawolajKucharza();
        Boolean rezultat = kuchnia.zlecPrzygotowanie(potrawa);
        return rezultat;
    }

    public Kawa zamowKawe(String opis) {
        System.out.println("[Bhadramurti]\n"
                + "Acyutananda idę do magazynu zobaczyć czy mamy wszystkie skłądniki bo się mi właśnie skończyły.");
        magazyn.sprawdz(opis);
        System.out.println("...[15 minut]...");
        kuchnia.zawolajKucharza();
        kuchnia.zlecPrzygotowanie(opis);
        kadry.zwolnijKucharza("ZWOLNIJ GO!");
        System.out.println("[Bhadramurti]\n"
                + "Acyutananda, sama zrobię klientowi " + Klient.instancja().getImie() + " kawę jaką tylko umiem. Idę do kuchni a ty pilnuj by nie uciekł.");
        System.out.println("...[słychać ogromny krzyk i płacz w kuchni]...");
        return kuchnia.zrobKawe(1);
    }

    public Kawa kawaDoDeseru(String opis) {
        System.out.println("[Narraor]\n Acyutananda przygotowuje swoją specjalną kawę klientowi " + Klient.instancja().getImie() + " w kuchni.");
        return kuchnia.zrobKawe(2);
    }

    public Deser zamowDeser(String opis) {
        System.out.println("[Bhadramurti]\n"
                + "Acyutananda jesteś szalony z tym ciągłym przepraszaniem i dogadzaniem klientowi " + Klient.instancja().getImie() + "! Zwolniliśmy kucharza, a ja połąmałam sobie paznokcie robiąc mu kawę.\n"
                + "Mam już dosyć na dzisiaj. Sam go sobie obsługuj!");
        System.out.println("[Narrator]\n"
                + "Acyutananda zamawia deser w cukierni.");
        return cukiernia.zamowDeser(opis);
    }

    public void przywitanie(String zamowienie) {
        System.out.println("[Bhadramurti]\n"
                + "Cześć Acyutananda, zauważyłam że mamy klienta. Właśnie się dowiedziałam, że nie ma dzisiaj naszego kucharza Ludomira.\n"
                + "Muszę to zgłosić w kadrach.");
        String telefon = baza.pobierzTelefon("Ludomir");
        kadry.zglosBrakPracownika(telefon, "Ludomir");
        System.out.println("[Bhadramurti]\n"
                + "Już jestem z powrotem. Czy " + Klient.instancja().getImie() + " coś zamówił?\n"
                + "[Acyutananda]\n"
                + zamowienie + "\n"
                + "OK. Już wołam zastępce kucharza.");
    }

}
