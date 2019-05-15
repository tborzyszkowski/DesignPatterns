import java.io.Serializable;
import java.io.ObjectStreamException;

public class SingletonClass implements Serializable {
	
	private static final long serialVersionUID = 1L;
	
	private static volatile SingletonClass instance = null;
	
	private boolean isConnected = true;
	private String value = "abc";
	
	private SingletonClass() {
		if(instance != null) {
			throw new RuntimeException("Use getInstance() method to create a singleton");
		}
	}
	
	public static SingletonClass getInstance() {
		if(instance == null) {
			//thread save
			synchronized(SingletonClass.class) {
				if(instance == null) {
					instance = new SingletonClass();
				}
			}
		}
		return instance;
	}
	
	//serialization save
	//replacing the object read from the stream
	//when an object is read, replace it with the singleton instance
	
	protected Object readResolve() throws ObjectStreamException {
		//when there is no instance - get one from file
		if(instance == null) instance = this;
		instance.setValue(this.getValue());
		instance.setConnection(this.getConnection());
		
		return getInstance();
	}
	
	public static void cleanSingleton() {
		instance = null;
	}
	
	public void setConnection(boolean connStatus) {
		isConnected = connStatus;
	}
	
	public boolean getConnection() {
		return isConnected;
	}

	public void setValue(String newVal) {
		value = newVal;
	}
	
	public String getValue() {
		return value;
	}
	

}
