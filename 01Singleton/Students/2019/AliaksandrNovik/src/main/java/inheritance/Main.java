package inheritance;

public class Main {

	public static void main(String[] args) {

		ISingleton parent = SingletonParent.getInstance();
		System.out.println(parent.hashCode() + " parent");		

		
		ISingleton childA = SingletonChildA.getInstance();
		System.out.println(childA.hashCode() + " childA");	


		
		ISingleton childB = SingletonChildB.getInstance();
		System.out.println(childB.hashCode() + " childB");

				
	
		
		
		System.out.println("Parent " + parent.getClass().getSimpleName() + " " + parent.hashCode());
		System.out.println("ChildA " + childA.getClass().getSimpleName() + " " + childA.hashCode());
		System.out.println("ChildB " + childB.getClass().getSimpleName() + " " + childB.hashCode());

	}

}
