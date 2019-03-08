package inheritance;

public class Main {

	public static void main(String[] args) {

		ISingleton parent = SingletonParent.getInstance();
		System.out.println(parent.hashCode());
		
		
		ISingleton childB = SingletonChildB.getInstance();
		System.out.println(childB.hashCode());

		ISingleton childA = SingletonChildA.getInstance();
		System.out.println(childA.hashCode());
		
		
		System.out.println("Parent " + parent.getClass().getSimpleName());
		System.out.println("ChildA" + childA.getClass().getSimpleName());
		System.out.println("ChildB" + childB.getClass().getSimpleName());

	}

}
