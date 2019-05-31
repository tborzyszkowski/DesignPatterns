package ZAD2;

public class AcousticGuitar implements IGuitar {

    String[] stringLetters = {"E","A","D","G","B","E"};
    int stringNum = 6;
    int capoFret = 0;


    @Override
    public void play(String technique, String title) {

        System.out.println("Graj " + title + " techniką " + technique);
        System.out.println("♪ ♫♬♪♫♬ ♪♫ ♬♪ ♫♬\n");
    }

    @Override
    public void tune() {
        for (int i = 0; i< stringNum; i++){
            System.out.println("Strojenie dźwięku " + stringLetters[i] + " na strunie " + (i+1) + ".");
        }

    }

    @Override
    public void adjustTheTone(int halfTone) {
        if(capoFret + halfTone < 0) {
            capoFret = 0;
        }
        else if(capoFret + halfTone > 18) {
            capoFret = 18;
        }else capoFret = halfTone;
        System.out.println("Kapodaster na " + capoFret + " poprzeczce.");
    }

}
