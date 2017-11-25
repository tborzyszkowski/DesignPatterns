package singletonEnum;
//enum

public class SingletonEnumTest {
	public static void main(String[] args) {
		
		SingletonEnum object1 = SingletonEnum.INSTANCE;
		System.out.println(object1.hashCode());
		
		SingletonEnum object2 = SingletonEnum.INSTANCE;
		System.out.println(object2.hashCode());
		
		SingletonEnum object3 = SingletonEnum.INSTANCE;
		System.out.println(object3.hashCode());
	}
}
