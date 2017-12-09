package com.marchwinski.prototype.streamcopy;

import com.marchwinski.prototype.constructorCopy.*;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class StreamCloneTester {
    public static void main(String[] args) {
        Sandwich motherSandwich = new Sandwich(new Meat("Baleron", 3), new Cheese(new KindOfCheese("Edamski"), 7), new Sauce("Kieczup"));
        Sandwich sonSandwich = (Sandwich)deepClone(motherSandwich);

        System.out.println("Mama " + motherSandwich);
        System.out.println("Son " + sonSandwich);

        sonSandwich.getMeat().setNumberOfSlices(300);

        System.out.println("Mama " + motherSandwich);
        System.out.println("Son " + sonSandwich);
    }


    public static Object deepClone(Object object) {
        try {
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            ObjectOutputStream oos = new ObjectOutputStream(baos);
            oos.writeObject(object);
            ByteArrayInputStream bais = new ByteArrayInputStream(baos.toByteArray());
            ObjectInputStream ois = new ObjectInputStream(bais);
            return ois.readObject();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

}
