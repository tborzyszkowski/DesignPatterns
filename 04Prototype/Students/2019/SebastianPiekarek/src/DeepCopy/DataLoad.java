package DeepCopy;


import DeepCopy.Voivodeships.Pomeranian;
import DeepCopy.Voivodeships.Voivodeship;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.Hashtable;
import java.util.LinkedList;

public class DataLoad {

    private static Hashtable<String, Voivodeship> voivodeshipList = new Hashtable<>();

    public static Voivodeship getVoivodeship(String spotType) {
        Voivodeship cachedVoivodeship = voivodeshipList.get(spotType);
       return cachedVoivodeship;
    }


    public static void loadCache(String name) throws IOException {

        LinkedList<String[]> pom = new LinkedList<>();

        BufferedReader reader = new BufferedReader(new FileReader(name));
        String line;

        while ((line = reader.readLine()) != null) {
            String[] words = line.split(";");

            switch (words[0]){
                case "22":
                    pom.add(words);
                    break;
            }
        }
        Voivodeship pomeranian = new Pomeranian("Pomorskie", pom);
        voivodeshipList.put("Pomorskie",pomeranian);


    }
}

