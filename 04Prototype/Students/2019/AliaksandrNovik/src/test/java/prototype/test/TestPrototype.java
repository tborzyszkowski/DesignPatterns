package prototype.test;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

import java.util.Arrays;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import prototype.Group;
import prototype.GroupManager;
import prototype.GroupPrototype;
import prototype.Schedule;
import prototype.ScheduleManager;
import prototype.Student;
import prototype.StudentManager;
import prototype.Subject;

public class TestPrototype {
	private Subject sub1, sub2, sub3, sub4;

	private List<Subject> subList1, subList2, subList3, subList4;

	private Student s1, s2, s3, s4;

	private List<Student> studL1, studL2;

	private Group g1, g2;
	
	private List<GroupPrototype> gp1, gp2;

	private Schedule sch1, sch2;
	
	private StudentManager studentManager;

	private GroupManager groupManager;

	private ScheduleManager scheduleManager;

	@Before
	public void beforeEach() {
		sub1 = new Subject("MATH");
		sub2 = new Subject("GEOMETRY");
		sub3 = new Subject("BIOLOGY");
		sub4 = new Subject("DESIGN_PATTERNS");

		subList1 = Arrays.asList(sub1, sub2, sub3, sub3, sub4);
		subList2 = Arrays.asList(sub1, sub2, sub3);
		subList3 = Arrays.asList(sub1, sub2);
		subList4 = Arrays.asList(sub1);

		s1 = new Student("Jan", "Kowalski", 235202, subList1);
		s2 = new Student("Roman", "Ejankowski", 253248, subList2);
		s3 = new Student("Gosia", "Malasiewicz", 225294, subList3);
		s4 = new Student("Jan", "Nowak", 243674, subList4);

		studL1 = Arrays.asList(s1, s2);
		studL2 = Arrays.asList(s3, s4);

		g1 = new Group(1, studL1, sub3);
		g2 = new Group(2, studL2, sub1);

		gp1 = Arrays.asList(g1);
		gp2 = Arrays.asList(g2);

		sch1 = new Schedule(3, 2, gp1);
		sch2 = new Schedule(2, 2, gp2);
		
		studentManager = new StudentManager();
		studentManager.addStudent("1", s1);
		studentManager.addStudent("2", s1);
		studentManager.addStudent("3", s1);
		studentManager.addStudent("4", s1);
		
		groupManager = new GroupManager();
		groupManager.addGroup("I", g1);
		groupManager.addGroup("II", g2);
		
		scheduleManager = new ScheduleManager();
		scheduleManager.addSchedule("1", sch1);
		scheduleManager.addSchedule("2", sch2);
	}
	
	@Test
	public void studentCopy() throws CloneNotSupportedException {
		System.out.println("STUDENT COPY START ==============================================");
		Student studentShallowCopy = (Student) studentManager.getStudent("1").shallowCopy();
		Student studentDeepCopy = (Student) studentManager.getStudent("1").deepCopy();
		System.out.println("STUDENT SHALLOW COPY: " + studentShallowCopy);
		System.out.println("STUDENT DEEP COPY: " + studentDeepCopy);
		System.out.println("STUDENT COPY END ================================================");

	}
	
	@Test
	public void groupCopy() throws CloneNotSupportedException {
		System.out.println("GROUP COPY START ================================================");
		Group groupShallowCopy = (Group) groupManager.getGroup("I").shallowCopy();
		Group groupDeepCopy = (Group) groupManager.getGroup("I").deepCopy();
		System.out.println("GROUP SHALLOW COPY: " + groupShallowCopy);
		System.out.println("GROUP DEEP COPY: " + groupDeepCopy);
		System.out.println("GROUP COPY END ==================================================");
	}
	
	@Test
	public void scheduleCopy() throws CloneNotSupportedException {
		System.out.println("SCHEDULE COPY START ==============================================");
		Schedule scheduleShallowCopy = (Schedule) scheduleManager.getSchedule("1").shallowCopy();
		Schedule scheduleDeepCopy = (Schedule) scheduleManager.getSchedule("1").deepCopy();
		System.out.println("SCHEDULE SHALLOW COPY: " + scheduleShallowCopy);
		System.out.println("SCHEDULE DEEP COPY: " + scheduleDeepCopy);
		System.out.println("SCHEDULE COPY END ================================================");

	}
	
	@Test
	public void studentDeepChangeCopy() throws CloneNotSupportedException {
		System.out.println("STUDENT DEEP CHANGE COPY START ===================================");
		Student studentDeepCopy1 = (Student) studentManager.getStudent("1").deepCopy();
		Student studentDeepCopy2 = (Student) studentManager.getStudent("1").deepCopy();
		studentDeepCopy1.setRecordNumber(111111);
		System.out.println("STUDENT SHALLOW COPY: " + studentDeepCopy1);
		System.out.println("STUDENT DEEP COPY: " + studentDeepCopy2);
		System.out.println("STUDENT DEEP CHANGE COPY END =====================================");

	}

}
