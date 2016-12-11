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
public class FabrykaKodekow {

    private static FabrykaKodekow fabryka = null;

    private FabrykaKodekow() {
    }

    public static FabrykaKodekow instacja() {
        if (fabryka == null) {
            fabryka = new FabrykaKodekow();
        }
        return fabryka;
    }

    public Kodeki pobierz(String nazwapliku) {
        Kodeki kodek;
        if (new DiviX().wspomaganeFormaty.contains(nazwapliku)) {
            return kodek = new DiviX();
        } else if (new Grafika().wspomaganeFormaty.contains(nazwapliku)) {
            return kodek = new Grafika();
        } else {
            System.out.println("Brak kodeku");
            return kodek = null;
        }

    }
}
