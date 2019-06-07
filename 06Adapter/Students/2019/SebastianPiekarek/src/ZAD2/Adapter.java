package ZAD2;

public class Adapter implements IPiano{

    private IGuitar guitar;


    Adapter(IGuitar guitar){
        this.guitar = guitar;
    }

    @Override
    public void play(String title) {
        guitar.play("Klasyczna", title);
    }

    @Override
    public void tune() {
        guitar.tune();
    }

    @Override
    public void adjustTheTone(int halfUp) {
        guitar.adjustTheTone(halfUp);
    }
}
