package DoubleCheck;


import java.util.stream.IntStream;

public class DoubleCheckTest {
    public static void main(String[] args) {
        IntStream.range(0,20).parallel().forEach(i->{
            SingletonDoubleCheck.getInstance();
        });
    }
}
