package ZAD2;

public class TestAdapter {

    public static void main(String[] args) {
        System.out.println("Gitara akustyczna:");
        AcousticGuitar acousticGuitar = new AcousticGuitar();
        acousticGuitar.tune();
        acousticGuitar.adjustTheTone(3);
        acousticGuitar.play("Alternate picking", "Paradise city");

        System.out.println("---------------------------------------------------------------------------");

        System.out.println("Pianino elektryczne:");
        ElectricPiano electricPiano = new ElectricPiano();
        electricPiano.tune();
        electricPiano.adjustTheTone(-2);
        electricPiano.play("Für Elise");

        System.out.println("---------------------------------------------------------------------------");

        System.out.println("Adapter gitary:");
        Adapter adaptPiano = new Adapter(new AcousticGuitar());
        adaptPiano.tune();
        adaptPiano.adjustTheTone(-2);
        adaptPiano.play("Hit the road Jack");

    }
}
