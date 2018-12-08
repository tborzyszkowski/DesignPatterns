package Serialization;


public class SerializationTest {
    public static void main(String[] args) {
        SerializationSingleton s1 = SerializationSingleton.getInstance();
        System.out.println(s1.hashCode());

        SerializationSingleton s2 = SerializationSingleton.getInstance();
        System.out.println(s2.hashCode());
    }
}
