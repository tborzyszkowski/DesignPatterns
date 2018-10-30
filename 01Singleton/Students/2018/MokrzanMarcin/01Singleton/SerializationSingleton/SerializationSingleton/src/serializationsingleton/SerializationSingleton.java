/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package serializationsingleton;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;

/**
 *
 * @author Marcin
 */
public class SerializationSingleton {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws FileNotFoundException, IOException, ClassNotFoundException {
        SingletonClass serialization = SingletonClass.getInstance();
        ObjectOutput out = new ObjectOutputStream(new FileOutputStream(
                "filename.txt"));
        out.writeObject(serialization);
        out.close();
    
    ObjectInput in = new ObjectInputStream(new FileInputStream(
                "filename.txt"));
        SingletonClass serializationTwo = (SingletonClass) in.readObject();
        in.close();
        
        System.out.println("first launching hashCode: "+serialization.hashCode());
        System.out.println("second launching hashCode: "+serializationTwo.hashCode());
    }
}
