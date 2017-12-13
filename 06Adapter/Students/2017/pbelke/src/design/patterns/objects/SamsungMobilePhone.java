package design.patterns.objects;

public class SamsungMobilePhone implements MobilePhone {

    @Override
    public void pickNumber() {
        System.out.println("Wybierz na ekranie dotykowym numer, pod który chcesz zadzwonić");
    }

    @Override
    public void saveNumber() {
        System.out.println("Zapisz telefon na karcie SIM");
    }
}
