package DeepCopy.Voivodeships.Counties;

import DeepCopy.Voivodeships.Counties.SpotList.*;


import java.util.Hashtable;
import java.util.Iterator;
import java.util.LinkedList;

public abstract class County implements Cloneable{

    private String type;
    private Hashtable<Integer, Spot> boulevardsList = new Hashtable<>();
    private Hashtable<Integer, Spot> coastsList = new Hashtable<>();
    private Hashtable<Integer, Spot> parksList = new Hashtable<>();
    private Hashtable<Integer, Spot> squarPlaceList = new Hashtable<>();
    private Hashtable<String, Hashtable<Integer, Spot>> spotMap = new Hashtable<String, Hashtable<Integer, Spot>>();

    County(String name, LinkedList spots){

        Iterator namesIterator = spots.iterator();
        this.type = name;
        while (namesIterator.hasNext()) {
            String[] words = (String[]) namesIterator.next();
            String word = words[8].equals("") ? words[7] : words[8] + " " + words[7];
            switch (words[6]){
                case "bulw.":
                    boulevardsList.put(boulevardsList.size()+1, new Boulevard(word));
                    break;
                case "skwer":
                    squarPlaceList.put(squarPlaceList.size()+1, new SquarePlace(word));
                    break;
                case "park":
                    parksList.put(parksList.size()+1, new Park(word));
                    break;
                case "wyb.":
                    coastsList.put(coastsList.size()+1, new Coast(word));
                    break;
            }
            spotMap.put("Bulwar", boulevardsList);
            spotMap.put("Skwer", squarPlaceList);
            spotMap.put("Parks",parksList);
            spotMap.put("Wybrzeże", coastsList);

        }

    }


    public void editObject(String type, int index, String target){
        (spotMap.get(type).get(index)).edit(target);
    }

    public void addObject(String type, String name){
        switch (type){
            case("Bulwar"):
                spotMap.get(type).put(spotMap.get(type).size()+1, new Boulevard(name) );
                break;
            case("Wybrzeże"):
                spotMap.get(type).put(spotMap.get(type).size()+1, new Coast(name) );
                break;
            case("Parks"):
                spotMap.get(type).put(spotMap.get(type).size()+1, new Park(name) );
                break;
            case("Skwer"):
                spotMap.get(type).put(spotMap.get(type).size()+1, new SquarePlace(name) );
                break;
        }

    }

    public Spot getObject(String type, int index) {

        return spotMap.get(type).get(index);
    }


    public String getName(){
        return type;
    }


    private String iterateHashMap(Hashtable hashMap, String type){
        String result = "   + " + type + ":\n";
        for(int i = 1; i <= hashMap.size(); i++)
            result += hashMap.get(i);
        return result;
    }


    public County clone() {
        County clone = null;

        try {
            clone = (County) super.clone();
            clone.boulevardsList = new Hashtable<>();
            for(Integer key : boulevardsList.keySet()){
                clone.boulevardsList.put(key, boulevardsList.get(key).clone());
            }
            clone.parksList = new Hashtable<>();
            for(Integer key : parksList.keySet()){
                clone.parksList.put(key, parksList.get(key).clone());
            }
            clone.coastsList = new Hashtable<>();
            for(Integer key : coastsList.keySet()){
                clone.coastsList.put(key, coastsList.get(key).clone());
            }
            clone.squarPlaceList = new Hashtable<>();
            for(Integer key : squarPlaceList.keySet()){
                clone.squarPlaceList.put(key, squarPlaceList.get(key).clone());
            }
            clone.spotMap = new Hashtable<>();
            clone.spotMap.put("Bulwar", clone.boulevardsList);
            clone.spotMap.put("Skwer", clone.squarPlaceList);
            clone.spotMap.put("Parks",clone.parksList);
            clone.spotMap.put("Wybrzeże", clone.coastsList);

        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }

        return clone;
    }


    @Override
    public String toString() {
        String result = type + ":\n";

        result += ((boulevardsList.size() != 0) ? iterateHashMap(boulevardsList, "Bulwar") : "");
        result += (squarPlaceList.size() != 0) ? iterateHashMap(squarPlaceList, "Skwer") : "";
        result += (parksList.size() != 0) ? iterateHashMap(parksList, "Parks") : "";
        result += (coastsList.size() != 0) ? iterateHashMap(coastsList, "Wybrzeże") : "";


        return result +"\n";
    }

}
