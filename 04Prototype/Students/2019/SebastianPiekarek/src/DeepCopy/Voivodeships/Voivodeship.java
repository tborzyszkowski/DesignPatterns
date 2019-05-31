package DeepCopy.Voivodeships;

import DeepCopy.Voivodeships.Counties.County;
import java.util.Hashtable;

public abstract class Voivodeship implements Cloneable {


    protected String type;
    protected Hashtable<String, County> counties = new Hashtable<>();

    public County getCity(String city){
        return counties.get(city);
    }


    @Override
    public String toString() {
        String result = type + ":\n";
        String gap = "> ";

        for(String key : counties.keySet()){
            result += gap + counties.get(key);
        }

        return result;
    }

    public Voivodeship clone() {
        Voivodeship clone = null;

        try {
            clone = (Voivodeship) super.clone();
            clone.counties = new Hashtable<>();

            for(String key : counties.keySet()){
                clone.counties.put(key, counties.get(key).clone());
            }


        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }

        return clone;
    }





}
