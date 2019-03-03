import java.util.ArrayList;
import java.util.List;

public class GenerujRaport {

    private List<Visitable> data;

    public void addData(Visitable data){
        getData().add(data);
    }

    public void visit(Visitor visitor){
        for (Visitable resident : getData()) {
            resident.accept(visitor);
        }
    }

    private List<Visitable> getData(){
        if(data == null){
            data = new ArrayList<Visitable>();
        }
        return data;
    }
}
