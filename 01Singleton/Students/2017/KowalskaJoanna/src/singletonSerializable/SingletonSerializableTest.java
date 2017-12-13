package singletonSerializable;
//Serializable

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;

public class SingletonSerializableTest {
	public static void main(String[] args) throws Exception {
		
		SingletonSerializable object1 = SingletonSerializable.pobierzInstancje();
		System.out.println(object1.hashCode());

		ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream("object1.ser"));
		out.writeObject(object1);
		
		ObjectInputStream in = new ObjectInputStream(new FileInputStream("object1.ser"));
		SingletonSerializable object2 = (SingletonSerializable)in.readObject();		
		System.out.println(object2.hashCode());
	}
}
