package ShallowCopy.SpotList;

import java.util.LinkedList;

public abstract class Spots implements Cloneable {

    private String type;
    private LinkedList<String> names;


    public Spots(String type, LinkedList<String> names){
        this.type = type;
        this.names = names;
    }


    public String getType(){
        return type;
    }

    public void removeItem(String name){
        names.remove(name);
    }

    public void removeItem(int index){
        names.remove(index);
    }


    public void editItem(int index, String value){
        names.set(index, value);
    }

    public void addItem( String value){
        names.add(value);
    }

    public String getItem(int index){
        return names.get(index);
    }



    @Override
    public String toString() {
        String result = type + ":\n";
        String gap = " - ";

        for(String spot : names){
            result += gap + spot + ",\n";
        }

        return result;
    }


    public Spots clone() {
        Spots clone = null;

        try {
            clone = (Spots) super.clone();
            LinkedList<String> copyNames = new LinkedList<>(names);
            clone.names = copyNames;

        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }

        return clone;
    }

}
