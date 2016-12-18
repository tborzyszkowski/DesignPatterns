/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AdapterPluggablePrzyklad;

/**
 *
 * @author KrzysieK
 */
public class OdtwarzaczMultimedialny {
    private FabrykaKodekow fabryka = FabrykaKodekow.instacja();
    

// simple factory
    private Kodeki pobierzKodeki(String typPliku){
        return fabryka.pobierz(typPliku);
    }

    public void odtworz(String plik) {
        Kodeki kodek = pobierzKodeki(rozszerzenie(plik));
        if (kodek != null) {
            System.out.println("Odtwarzam plik: " + nazwa(plik) + " przy pomocy kodeku " + kodek.nazwa);
        } 
    }

    private String rozszerzenie(String nazwapliku) {
        String tekst = "";
        int i = nazwapliku.lastIndexOf('.');
        if (i > 0) {
            tekst = nazwapliku.substring(i + 1);
        }
        return tekst;
    }

    private String nazwa(String nazwapliku) {
        String tekst = "";
        int i = nazwapliku.lastIndexOf('.');
        if (i > 0) {
            tekst = nazwapliku.substring(0, i);
        }
        return tekst;
    }
}
