import java.util.*;

class User {
	int id;
	String name;
	String lastName;
	int age;

	User(int id, String name, String lastName, int age) {
		this.id = id;
		this.name = name;
		this.lastName = lastName;
		this.age = age;
	}

	public String toString() {
		return "<User: " + id + " ," + name + " ," + lastName + " ," + age + ">";
	}
}

public class Passive {

	public static void main(String[] args) {
		ArrayList<User> users = new ArrayList<User>(
				Arrays.asList(new User(1, "Steve", "Vai", 40), 
						new User(4, "Joe", "Smith", 32),
						new User(3, "Steve", "Johnson", 57), 
						new User(9, "Mike", "Stevens", 18),
						new User(10, "George", "Armstrong", 24), 
						new User(2, "Jim", "Smith", 40),
						new User(8, "Chuck", "Schneider", 34), 
						new User(5, "Jorje", "Gonzales", 22),
						new User(6, "Jane", "Michaels", 47), 
						new User(7, "Kim", "Berlie", 60)));

		
		System.out.println("\nu.age > 50");
		users
			.stream()
			//.filter(u -> u.age > 50)
			.forEach(u -> System.out.println(u));
		System.out.println();
		users
			.parallelStream()
			//.filter(u -> u.age > 50)
			.forEach(u -> System.out.println(u));

//		System.out.println("\nCount: " + 
//					users
//						.stream()
//						.filter(u -> u.name.startsWith("S"))
//						.count()
//						);
//
//		System.out.println("\ntoUpperCase:");
//		users
//			.stream()
//			.filter(u -> u.age > 40)
//			.map(u -> u.name.toUpperCase())
//			.forEach( u -> System.out.println(u) );
//
//		System.out.println("\nmin:");
//		User uMin = users
//						.stream()
//						.min(Comparator.comparing(u -> u.lastName.length()))
//						.get();
//		System.out.println(uMin);
//
//		System.out.println("\nreduced:");
//		String reduced = users
//							.stream()
//							.map(u -> u.name)
//							.reduce("", (acc, n) -> acc + " " + n);
//		System.out.println(reduced);
//
//		System.out.println("\naverage age:" + 
//						users
//							.stream()
//							.mapToInt(u -> u.age)
//							.average());
	}
}