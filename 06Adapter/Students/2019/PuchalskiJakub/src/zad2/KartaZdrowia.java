package zad2;

public class KartaZdrowia implements I_KartaZdrowia {

    private String imie;
    private double wzrost;
    private double waga;

    public KartaZdrowia(String imie, double wzrost, double waga) {
        this.imie = imie;
        this.wzrost = wzrost;
        this.waga = waga;
    }

    @Override
    public String imie() {
        return imie;
    }

    @Override
    public double wzrostWCm() {
        return wzrost;
    }

    @Override
    public double wagaWKg() {
        return waga;
    }

    @Override
    public void wyswietl() {
        System.out.println(
                "KARTA ZDROWIA" + "\n"
                        + "Imię: " + imie + "\n"
                        + "Waga: " + wzrost + "\n"
                        + "Wzrost: " + waga
        );
    }
}
