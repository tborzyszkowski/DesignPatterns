/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

/**
 *
 * @author KrzysieK
 */
public class Kadry {

    public Kadry() {

    }

    public void zglosBrakPracownika(String telefon, String nazwa) {
        System.out.println("[Kadry]\nCześć tu Dorota z działu kadr, nie mogę rozmawiać bo maluję paznokcie i oglądam koty na Fejsie.\n"
                + "zostaw wiadomość po sygnale DZYŃ... \n"
                + "[Skrzynka przepełniona - brak możliwości zostawienia wiadomości o braku " + nazwa + " w pracy.]");
    }

    public void zwolnijKucharza(String polecenie) {
        StringBuilder display = new StringBuilder();
        display.append("[Kadry]\n");
        display.append("Cześć Bhadramurti, tu Dorota.... tak znam tego kucharza jest wysoki, przystojny i ma takie śliczne oczy...no i nie umie gotować. \n");
        display.append("[Bhadramurti]\n").append(polecenie);
        display.append("\n[Kadry]\n");
        display.append("Dobrze...[słychać płacz]. Już przygotowuję mu wypowiedzenie");
        System.out.println(display.toString());
    }
}
