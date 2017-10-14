package com.company;

import java.io.*;

/**
 * Created by mjakobowski on 17.12.16.
 */
public class SingletonSerializableDemo {

    static Singleton sing = Singleton.getInstance();
    static Singleton s1  = null;
    static Singleton s2 = null;
    public static void main(String[] args) {
        try {
            FileOutputStream fileOut =
                    new FileOutputStream("./singleton.ser");
            ObjectOutputStream out = new ObjectOutputStream(fileOut);
            out.writeObject(sing);
            out.close();
            fileOut.close();
            System.out.println("Serialized data is saved");

            Thread t = new Thread(new Runnable() {
                @Override
                public void run() {
                    FileInputStream fileIn1 = null;
                    try {
                        fileIn1 = new FileInputStream("./singleton.ser");
                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    }
                    try {
                        System.out.println(Singleton.getInstance());
                        ObjectInputStream in1 = new ObjectInputStream(fileIn1);
                        s1 = (Singleton) in1.readObject();
                        System.out.println(s1.hashCode() + " "+ s1.i);

                        s1.i = 10;
                        System.out.println(s1.hashCode() + " "+ s1.i);
                        in1.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    } catch (ClassNotFoundException e) {
                        e.printStackTrace();
                    }
                    try {
                        fileIn1.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            });

            Thread t2 = new Thread(new Runnable() {
                @Override
                public void run() {
                    FileInputStream fileIn2 = null;
                    try {
                        fileIn2 = new FileInputStream("./singleton.ser");
                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    }
                    try {
                        ObjectInputStream in2 = new ObjectInputStream(fileIn2);
                        s2 = (Singleton) in2.readObject();
                        System.out.println(Singleton.getInstance());
                        s2.i = 5;
                        System.out.println(s2.hashCode() + " "+ s2.i);
                        in2.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    } catch (ClassNotFoundException e) {
                        e.printStackTrace();
                    }
                    try {
                        fileIn2.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            });
            t.start();
            t2.start();
        }catch(Exception i) {
            i.printStackTrace();
        }
    }
}