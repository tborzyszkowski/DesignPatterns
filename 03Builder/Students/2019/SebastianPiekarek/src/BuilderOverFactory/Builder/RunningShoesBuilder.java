package BuilderOverFactory.Builder;

public class RunningShoesBuilder extends Builder {

    int[] sizes = new int[] {42,43,44,45,46,47,48,49};
    String[] colors = new String[] {"czerwony", "biały", "czarny"};

    @Override
    void setSize(int size) {
        for (int available : sizes){
            if(size == available) shoes.size = size;
        }
    }

    @Override
    void setFabric(String color) {
        for (String available : colors){
            if(color == available) shoes.fabric = "Syntetyczno-tekstylna cholewka";
        }
    }

    @Override
    void setSole(int price) {
        shoes.sole =  price > 1000 ? "Obniżona podeszwa środkowa" : "Sprężysta podeszwa środkowa";
    }

    @Override
    void setTie(int price) {
        shoes.tie =  price > 1000 ? "sznurowane" : "Zapięcie na rzep";
    }

    @Override
    public void setName() {
        shoes.brand = "NIKE";
        shoes.name = "Air Zoom Pegasus";
    }



}
