package serialization;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.Serializable;

public class SerializedSingleton implements Serializable {

	private static final long serialVersionUID = -5722183829628549906L;

	private int num;

	private SerializedSingleton() {
	}

	private static class SingletoneHelper {
		private static SerializedSingleton instance = new SerializedSingleton();
	}

	protected Object readResolve() {
		return getInstance();
	}

//	private void readObject(ObjectInputStream o) throws IOException, ClassNotFoundException {
//		o.defaultReadObject();
//		SingletoneHelper.instance = this;
//	}

	public static SerializedSingleton getInstance() {
		return SingletoneHelper.instance;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}

}