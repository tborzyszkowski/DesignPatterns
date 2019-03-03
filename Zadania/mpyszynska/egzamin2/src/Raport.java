import java.util.ArrayList;
import java.util.List;

public class Raport implements Visitable{

   /* public String numerRaportu;
    private List<Visitable> data;

    private ArrayList<Product> listaProduktow;
    private ArrayList<Klient> listaKlientow;

    public void addData(Visitable resident){
        getData().add(resident);
    }

    public void visit(Visitor visitor){
        for (Visitable data : getData()) {
            data.accept(visitor);
        }
    }

    private List<Visitable> getData(){
        if(data == null){
            data = new ArrayList<Visitable>();
        }
        return data;
    }

    public void accept(Visitor visitor) {
        visitor.visit(this);
    }*/

    public void accept(Visitor visitor) {
        visitor.visit(this);
    }
}
