/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Prototyp;

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
public abstract class Prototyp<T> implements Cloneable {

    public T KlonowaniePlytkie()  {
        T klon = null;
        try {
            klon = (T)this.clone();
        } catch (CloneNotSupportedException e) {
            System.out.println("Błąd");
        }       
        return klon;
    }
    
    public T KlonowanieGlebokie(T oryginal){
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
