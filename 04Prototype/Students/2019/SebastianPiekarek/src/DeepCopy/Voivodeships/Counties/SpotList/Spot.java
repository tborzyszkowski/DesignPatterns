package DeepCopy.Voivodeships.Counties.SpotList;



public abstract class Spot implements Cloneable {

    public String name;


    public Spot( String name){
        this.name = name;
    }

    public void edit(String target){
        this.name = target;
    }


    @Override
    public String toString() {
        return "     - " + name + ",\n";
    }


    public Spot clone() {
        Spot clone = null;

        try {
            clone = (Spot) super.clone();
            clone.name = name;

        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }
        return clone;
    }

}
