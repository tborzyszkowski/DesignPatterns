
import static org.junit.jupiter.api.Assertions.assertEquals;

public class Test {


    @org.junit.Test
    public void wizytatorTest(){
       Visitable raport = new Raport();
        GenerujRaport generujRaport = new GenerujRaport();
        generujRaport.addData(raport);

    }


}
