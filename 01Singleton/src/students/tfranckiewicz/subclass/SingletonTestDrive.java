/*
* 166122 Tomasz Franckiewicz
* Resolved problem with serialization/deserialization the singleton.
*/

package students.tfranckiewicz.subclass;
import java.io.*;

public class SingletonTestDrive {
	public static void main(String[] args) throws IOException {
		Thread thread1 = new Thread () {
			public void run () {
				try {
					Singleton instanceOne = Singleton.getInstance();
					ObjectOutput out = new ObjectOutputStream(new FileOutputStream("data.ser"));
					out.writeObject(instanceOne);
					out.close();
					System.out.println("instanceOne hashCode="+instanceOne.hashCode()+"/"+Thread.currentThread().getId());
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		};
		Thread thread2 = new Thread () {
			public void run () {
				try {
					Thread.sleep(50);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				try {
					ObjectInput in = new ObjectInputStream(new FileInputStream("data.ser"));
					Singleton instanceTwo = (Singleton) in.readObject();
					in.close();
					System.out.println("instanceTwo hashCode="+instanceTwo.hashCode()+"/"+Thread.currentThread().getId());
				} catch (IOException | ClassNotFoundException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		};
		
		thread1.start();
		thread2.start();
		
 	}
}
