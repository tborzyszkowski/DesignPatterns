package singletonserialization;

import java.io.FileNotFoundException;
import java.io.IOException;

/**
 *
 * @author pbelke
 */
public class SingletonSerialization {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws FileNotFoundException, IOException, ClassNotFoundException {
        Singleton instanceOne = Singleton.getInstance();
        FileReaderWriter.write(instanceOne);
        Singleton instanceTwo = (Singleton) FileReaderWriter.read();
        
        //TODO: testy na różne przypadki z dziedziczeniem, itd - serializacja
        //TODO dziedziczenie, wielowatkowosc (synchronized)
        System.out.println("instanceOne hashCode="+instanceOne.hashCode());
        System.out.println("instanceTwo hashCode="+instanceTwo.hashCode());
    }
}
