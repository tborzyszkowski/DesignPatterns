package SimpleFactory;

public abstract class Potion {

     protected String name;
     protected String description;

    public String getName() {
        return name;
    }



    public String getDescription() {
        return description;
    }


    public void addMagic()
    {
        System.out.println("Adding some magic!");
    }

    @Override
    public String toString() {
        return name + " - " + description;
    }
}
