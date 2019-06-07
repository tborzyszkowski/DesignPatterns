package ZAD2;

public class ElectricPiano implements IPiano {

    int keysNum = 88;
    String[] keysLetters = {"A", "B", "C", "D", "E", "F", "G"};


    @Override
    public void play(String title) {
        System.out.println("Graj " + title);
        System.out.println("♪♫♬ ♪♫ ♬ ♪♫ ♬♪ ♫ ♬\n");
    }

    @Override
    public void tune() {
        int keyNumber = 2;
        for (int i = 0; i < keysNum; i++){
            if(keyNumber == 6) keyNumber = 0;
            System.out.println("Kalibracja dźwięku " + keysLetters[keyNumber] + " na klawiszu " + (i+1) + ".");
            keyNumber++;
        }
    }

    @Override
    public void adjustTheTone(int halfTone) {

        System.out.println("Regulacja tonu za pomocą przycisku transpose.");
        System.out.println("Obecnie: " + halfTone + " razy pół tonu.");

    }
}
