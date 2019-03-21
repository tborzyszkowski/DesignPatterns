import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.Assertions;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.util.stream.IntStream;

class MainTest {

    @Test
    void setAndGetNameTest1() {
        King.INSTANCE.deleteCurrentKing();
        King.INSTANCE.setKingsName("Król Testowy");
        Assertions.assertEquals("Aktualnym królem jest: " + "Król Testowy", King.INSTANCE.getKingsName());
        System.out.println();
    }

    @Test
    void setAndGetNameTest2() {
        King.INSTANCE.setKingsName("Król Testowy 2");
        Assertions.assertEquals("Aktualnym królem jest: " + "Król Testowy 2", King.INSTANCE.getKingsName());
        System.out.println();
    }

    @Test
    void serializeTest1() throws IOException, ClassNotFoundException {
        King.INSTANCE.setKingsName("Kazimierz Serializacyjny");
        King.serialize();
        King.INSTANCE.setKingsName("Władysław Testowy");
        King.deserialize();
        Assertions.assertEquals("Aktualnym królem jest: " + "Kazimierz Serializacyjny", King.INSTANCE.getKingsName());;
        System.out.println();
    }

    @Test
    void serializeTest2() throws IOException, ClassNotFoundException {
        King.INSTANCE.setKingsName("Kazimierz Serializacyjny");
        int hashCodeBefore = King.INSTANCE.hashCode();
        King.serialize();
        King.INSTANCE.setKingsName("Władysław Testowy");
        King.deserialize();
        int hashCodeAfter = King.INSTANCE.hashCode();
        Assertions.assertEquals(hashCodeBefore, hashCodeAfter);
        System.out.println();
    }

    @Test
    void multiThread() {
        IntStream.range(0, 10).parallel().forEach(i ->  {
            King.INSTANCE.setKingsName("Król Testowy");
        });

        Assertions.assertEquals("Aktualnym królem jest: " + "Król Testowy", King.INSTANCE.getKingsName());
    }

}