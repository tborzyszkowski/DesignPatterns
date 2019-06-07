package DeepCopy.Voivodeships;

import DeepCopy.Voivodeships.Counties.County;
import DeepCopy.Voivodeships.Counties.Gdansk;
import DeepCopy.Voivodeships.Counties.Gdynia;
import DeepCopy.Voivodeships.Counties.Sopot;

import java.util.Iterator;
import java.util.LinkedList;

public class Pomeranian extends Voivodeship {
    public Pomeranian(String type, LinkedList<String[]> names) {
        this.type = type;
        LinkedList<String[]> gda = new LinkedList<>();
        LinkedList<String[]> gd = new LinkedList<>();
        LinkedList<String[]> gsp = new LinkedList<>();

        Iterator namesIterator = names.iterator();
        while (namesIterator.hasNext()) {

            String[] words = (String[]) namesIterator.next();
            switch (words[1]) {
                case "62":
                    gda.add(words);
                    break;
                case "61":
                    gd.add(words);
                    break;
                case "64":
                    gsp.add(words);
                    break;
            }
        }

        County gdynia = new Gdynia("Gdynia", gda);
        this.counties.put(gdynia.getName(),gdynia);

        County gdansk = new Gdansk("Gdańsk", gd);
        this.counties.put(gdansk.getName(),gdansk);

        County sopot = new Sopot("Sopot", gsp);
        this.counties.put(sopot.getName(),sopot);
    }
}
