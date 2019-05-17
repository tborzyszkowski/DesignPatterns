package prototype;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.List;
import java.util.stream.Collectors;

public class Group extends GroupPrototype implements Cloneable, Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 12L;
	private int number;
	private List<Student> students;
	private Subject subject;

	public Group(int number, List<Student> students, Subject subject) {
		this.number = number;
		this.students = students;
		this.subject = subject;
	}

	public Group(Group group) throws CloneNotSupportedException {
		this(group.getNumber(), group.getAllStudents(group), group.getSubject());
	}

	private List<Student> getAllStudents(Group group) throws CloneNotSupportedException {
		return group.getStudents().stream()
				.map(s -> new Student(s.getFirsName(), s.getLastName(), s.getRecordNumber(), s.getAllSubjects(s)))
				.collect(Collectors.toList());
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

	@Override
	public GroupPrototype deepCopy() throws CloneNotSupportedException {
		System.out.println("Making GROUP deep copy: " + this.toString());

		try {
			ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
			ObjectOutputStream outputStrm = new ObjectOutputStream(outputStream);
			outputStrm.writeObject(this);

			ByteArrayInputStream inputStream = new ByteArrayInputStream(outputStream.toByteArray());
			ObjectInputStream objInputStream = new ObjectInputStream(inputStream);

			try {
				return (Group) objInputStream.readObject();
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			}

		} catch (IOException e) {
			e.printStackTrace();
		}

		return null;
	}
}
