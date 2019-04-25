import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.Test;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInput;
import java.io.ObjectInputStream;
import java.io.ObjectOutput;
import java.io.ObjectOutputStream;
import java.util.Collections;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

class SingletonClassTest {

	@Test
	void isSingleton() {
		SingletonClass instance1 = SingletonClass.getInstance();
		SingletonClass instance2 = SingletonClass.getInstance();
		assertEquals(instance1, instance2);
		assertEquals(instance1.hashCode(), instance2.hashCode());
	}
	
	
	@Test
	void isSingletonValue() {
		SingletonClass instance1 = SingletonClass.getInstance();
		SingletonClass instance2 = SingletonClass.getInstance();
		instance1.setConnection(true);
		instance2.setConnection(false);
		assertEquals(false, instance1.getConnection());
		assertEquals(false, instance2.getConnection());	
	}
	
	@Test
    public void isSerializable() throws IOException, ClassNotFoundException {
        SingletonClass serializedInstance = SingletonClass.getInstance();
     
        serialize(serializedInstance);
        
        serializedInstance.setValue("def");
        
        SingletonClass deserializedInstance = deserialize();
        
        System.out.println("First instance: " + serializedInstance.getValue());
        System.out.println("Second instance: " + deserializedInstance.getValue() + "\n");

        assertEquals(serializedInstance, deserializedInstance);
        assertEquals(serializedInstance.hashCode(), deserializedInstance.hashCode());
    }
	
	
	private void serialize(SingletonClass serializedInstance) throws IOException {
		ObjectOutput out = new ObjectOutputStream(new FileOutputStream("Singleton.ser"));
        out.writeObject(serializedInstance);
        out.close();
	}
	
	private SingletonClass deserialize() throws IOException, ClassNotFoundException {
		
		ObjectInput in = new ObjectInputStream(new FileInputStream("Singleton.ser"));
		SingletonClass deserializedInstance = (SingletonClass) in.readObject();
		in.close();
		return deserializedInstance;
		
	}
	
	@Test
	public void isThreadSafe() throws InterruptedException {
		int threadsAmount = 10;
	    Set<SingletonClass> singletonSet = Collections.newSetFromMap(new ConcurrentHashMap<>());

	    //This creates a thread pool with 10 threads executing tasks
	    ExecutorService executorService = Executors.newFixedThreadPool(threadsAmount);

	    for (int i = 0; i < threadsAmount; i++) {
	        executorService.execute(() -> {
	            SingletonClass singleton = SingletonClass.getInstance();
	            singletonSet.add(singleton);
	        });
	    }

	    executorService.shutdown();
	    executorService.awaitTermination(1, TimeUnit.MINUTES);

	    assertEquals(1, singletonSet.size());
	}
	
	
	@AfterEach
	public void clean() {
		SingletonClass.cleanSingleton();
	}

	
}
