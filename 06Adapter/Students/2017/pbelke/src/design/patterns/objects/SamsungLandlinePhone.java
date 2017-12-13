package design.patterns.objects;

public class SamsungLandlinePhone implements LandlinePhone {

    @Override
    public void pickNumber() {
        System.out.println("Wykręć numer na tarczy numerycznej");
    }

    @Override
    public void saveNumber() {
        System.out.println("Zapisz numer na kartce papieru");
    }
}
