package ShallowCopy;


import ShallowCopy.SpotList.*;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;

public class DataLoad {

    private static Hashtable<String, Spots> SpotMap = new Hashtable<>();

    public static Spots getSpot(String spotType) {
        Spots cachedShape = SpotMap.get(spotType);
       return cachedShape.clone();
    }


    public static void loadCache(String name) throws IOException {

        LinkedList<String> boulevards = new LinkedList<>();
        LinkedList<String> coasts = new LinkedList<>();
        LinkedList<String> parks = new LinkedList<>();
        LinkedList<String> squarePlaces = new LinkedList<>();

        BufferedReader reader = new BufferedReader(new FileReader(name));
        String line;

        while ((line = reader.readLine()) != null) {
            String[] words = line.split(";");

            switch (words[6]){
                case "skwer":
                    squarePlaces.add(words[8].equals("") ? words[7] : words[8] + " " + words[7]);
                    break;
                case "park":
                    parks.add(words[8].equals("") ? words[7] : words[8] + " " + words[7]);
                    break;
                case "bulw.":
                    boulevards.add(words[8].equals("") ? words[7] : words[8] + " " + words[7]);
                    break;
                case "wyb.":
                    coasts.add(words[8].equals("") ? words[7] : words[8] + " " + words[7]);
                    break;
            }


        }
        Spots boulevard = new Boulevards("Bulwar", boulevards);
        SpotMap.put(boulevard.getType(),boulevard);

        Spots coast = new Coasts("Wybrzeże", coasts);
        SpotMap.put(coast.getType(),coast);

        Spots park = new Parks("Parks", parks);
        SpotMap.put(park.getType(),park);

        Spots squarePlace = new SquarePlaces("Skwer", squarePlaces);
        SpotMap.put(squarePlace.getType(),squarePlace);

    }
}

