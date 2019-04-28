package prototype;

import java.util.List;

public class Group extends GroupPrototype implements Cloneable {

	private int number;
	private List<Student> students;
	private Subject subject;

	public Group(int number, List<Student> students, Subject subject) {
		this.number = number;
		this.students = students;
		this.subject = subject;
	}

	public int getNumber() {
		return number;
	}

	public void setNumber(int number) {
		this.number = number;
	}

	public List<Student> getStudents() {
		return students;
	}

	public void setStudents(List<Student> students) {
		this.students = students;
	}

	public Subject getSubject() {
		return subject;
	}

	public void setSubject(Subject subject) {
		this.subject = subject;
	}

	@Override
	public String toString() {
		return "Group [number=" + number + ", students=" + students + ", subject=" + subject + "]";
	}

	@Override
	public GroupPrototype shallowCopy() throws CloneNotSupportedException {
		System.out.println("Making GROUP swallow copy: " + this.toString());
		return (GroupPrototype) this.clone();
	}
}
