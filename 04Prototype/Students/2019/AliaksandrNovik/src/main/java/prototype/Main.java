package prototype;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

	public static void main(String[] args) throws CloneNotSupportedException {

		Subject sub1 = new Subject("MATH");
		Subject sub2 = new Subject("GEOMETRY");
		Subject sub3 = new Subject("BIOLOGY");
		Subject sub4 = new Subject("DESIGN_PATTERNS");

		List<Subject> subList1 = Arrays.asList(sub1, sub2, sub3, sub3, sub4);
		List<Subject> subList2 = Arrays.asList(sub1, sub2, sub3);
		List<Subject> subList3 = Arrays.asList(sub1, sub2);
		List<Subject> subList4 = Arrays.asList(sub1);

		Student s1 = new Student("Jan", "Kowalski", 235202, subList1);
		Student s2 = new Student("Roman", "Ejankowski", 253248, subList2);
		Student s3 = new Student("Gosia", "Malasiewicz", 225294, subList3);
		Student s4 = new Student("Jan", "Nowak", 243674, subList4);

		List<Student> studL1 = Arrays.asList(s1, s2);
		List<Student> studL2 = Arrays.asList(s3, s4);

		Group g1 = new Group(1, studL1, sub3);
		Group g2 = new Group(2, studL2, sub1);

		List<GroupPrototype> gp1 = Arrays.asList(g1);
		List<GroupPrototype> gp2 = Arrays.asList(g2);

		Schedule sch1 = new Schedule(3, 2, gp1);
		Schedule sch2 = new Schedule(2, 2, gp2);

		StudentManager studentManager = new StudentManager();
		studentManager.addStudent("1", s1);
		studentManager.addStudent("2", s1);
		studentManager.addStudent("3", s1);
		studentManager.addStudent("4", s1);

		GroupManager groupManager = new GroupManager();
		groupManager.addGroup("I", g1);
		groupManager.addGroup("II", g2);

		ScheduleManager scheduleManager = new ScheduleManager();
		scheduleManager.addSchedule("1", sch1);
		scheduleManager.addSchedule("2", sch2);

		System.out.println("STUDENT COPY START ==============================================");
		Student studentShallowCopy = (Student) studentManager.getStudent("1").shallowCopy();
		Student studentDeepCopy = (Student) studentManager.getStudent("1").deepCopy();
		System.out.println("STUDENT SHALLOW COPY: " + studentShallowCopy);
		System.out.println("STUDENT DEEP COPY: " + studentDeepCopy);
		System.out.println("STUDENT COPY END ================================================");

		System.out.println("GROUP COPY START ================================================");
		Group groupShallowCopy = (Group) groupManager.getGroup("I").shallowCopy();
		Group groupDeepCopy = (Group) groupManager.getGroup("I").deepCopy();
		System.out.println("GROUP SHALLOW COPY: " + groupShallowCopy);
		System.out.println("GROUP DEEP COPY: " + groupDeepCopy);
		System.out.println("GROUP COPY END ==================================================");

		System.out.println("SCHEDULE COPY START ==============================================");
		Schedule scheduleShallowCopy = (Schedule) scheduleManager.getSchedule("1").shallowCopy();
		Schedule scheduleDeepCopy = (Schedule) scheduleManager.getSchedule("1").deepCopy();
		System.out.println("SCHEDULE SHALLOW COPY: " + scheduleShallowCopy);
		System.out.println("SCHEDULE DEEP COPY: " + scheduleDeepCopy);
		System.out.println("SCHEDULE COPY END ================================================");

	}

}
