/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Singleton;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

/**
 *
 * @author KrzysieK
 * @param <T>
 */
public class Klonowanie<T> {
    public T duplikuj(T oryginal){
        T obiekt = null;
        try {
            // Write the object out to a byte array
            ByteArrayOutputStream tablicaBitow = new ByteArrayOutputStream();
            try (ObjectOutputStream out = new ObjectOutputStream(tablicaBitow)) {
                out.writeObject(oryginal);
                out.flush();
            }

            // Make an input stream from the byte array and read
            // a copy of the object back in.
            ObjectInputStream in = new ObjectInputStream(
                new ByteArrayInputStream(tablicaBitow.toByteArray()));
            obiekt = (T)in.readObject();
        }
        catch(IOException error) {
            error.printStackTrace();
        }
        catch(ClassNotFoundException error) {
            error.printStackTrace();
        }
        return obiekt;
    }
}
