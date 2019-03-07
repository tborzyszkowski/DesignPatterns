package enumsingletone;

public class Main {
	public static void main(String[] str) {
		EnumSingletone instanceOne = EnumSingletone.INSTANCE;
		EnumSingletone instanceTwo = EnumSingletone.INSTANCE;
		System.out.println(instanceOne.hashCode() == instanceTwo.hashCode());
		System.out.println(instanceOne.hashCode());

		ThreadOne first = new ThreadOne();
		first.start();

		System.out.println("Hash code is: " + first.getInstanceHashCode());

	}
}
