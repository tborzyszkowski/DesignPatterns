package Adapter;

/**
 * Created by K.Karkucinski on 2016-12-29.
 */
public class AdapterRodzinny implements  SportowySamochod{

    RodzinnySamochod rodzinny;

    public AdapterRodzinny(RodzinnySamochod rodzinny){
        this.rodzinny = rodzinny;
    }

    @Override
    public void spalanie() {
        rodzinny.spalaniePaliwa();
    }

    @Override
    public int getSzybkosc() {
        return rodzinny.getSzybkosc()+80;
    }

    @Override
    public String getKolor() {
        return rodzinny.getKolor()+" delikatnie przebija się spod nowego czeronego lakieru";
    }
}
