package StaticHolder;

import java.util.stream.IntStream;

public class StaticHolderTest {
    public static void main(String[] args) {
        IntStream.range(0,20).parallel().forEach(i->{
            SingletonStaticHolder.getInstance();
        });
    }
}
