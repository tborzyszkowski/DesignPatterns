package prototype;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

	public static void main(String[] args) throws CloneNotSupportedException {

		StudentPrototype pS = new Student("A", "B", 231432, Arrays.asList(new Subject("MATH")));
		
		
		List<Subject> subjects = new ArrayList<>();
		subjects.add(new Subject("MATH"));
		subjects.add(new Subject("DESIGN PATTERNS"));
		subjects.add(new Subject("GENERIC PROGRAMMING"));
		
		
		StudentManager studentManager = new StudentManager();
		GroupManager groupManager = new GroupManager();
		
		studentManager.addStudent("1", new Student("Jan", "Kowalski", 231432, Arrays.asList(new Subject("MATH"))));
		studentManager.addStudent("2", new Student("Andrzej", "Janowski", 231433, subjects));
		studentManager.addStudent("3", new Student("Kamil", "Jasinski", 231434, subjects));
		
		
		groupManager.addGroup("1", new Group(1, Arrays.asList(new Student("Jan", "Kowalski", 231432, Arrays.asList(new Subject("MATH")))), new Subject("MATH")));
		
		Group group = (Group)groupManager.getGroup("1").swallowCopy();
		
		Student s1 = (Student)studentManager.getStudent("2").swallowCopy();
		Student s2 = (Student)studentManager.getStudent("2");
		System.out.println(s1.getFirsName());
		System.out.println(s1.getSubjectList());
		System.out.println(s1.hashCode() + "   "+s2.hashCode());
		
	}

}
