package prototype;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class Student extends StudentPrototype implements Cloneable, Serializable {

	private static final long serialVersionUID = 123L;
	private String firsName;
	private String lastName;
	private List<Subject> subjectList;

	private int recordNumber;

	public Student(String firstName, String lastName, int recordNumber, List<Subject> subjectList) {
		this.firsName = firstName;
		this.lastName = lastName;
		this.recordNumber = recordNumber;
		this.subjectList = subjectList;
	}
	
//	public Student(Student student) {
//		this(student.getFirsName(), student.getLastName(), student.getRecordNumber(), student.getAllSubjects(student));
//	}

	public List<Subject> getAllSubjects(Student student) {
		List<Subject> subjects = new ArrayList<>();
		for(Subject s : student.getSubjectList()) {
			subjects.add(new Subject(s.getTitle()));
		}
		return subjects;
	}

	public String getFirsName() {
		return firsName;
	}

	public void setFirsName(String firsName) {
		this.firsName = firsName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public List<Subject> getSubjectList() {
		return subjectList;
	}

	public void setSubjectList(List<Subject> subjectList) {
		this.subjectList = subjectList;
	}

	public int getRecordNumber() {
		return recordNumber;
	}

	public void setRecordNumber(int recordNumber) {
		this.recordNumber = recordNumber;
	}

	@Override
	public String toString() {
		return "Student [firsName=" + firsName + ", lastName=" + lastName + ", recordNumber=" + recordNumber
				+ ", subjectList=" + subjectList + "]";
	}

	@Override
	public StudentPrototype shallowCopy() throws CloneNotSupportedException {
		System.out.println("Making Student SWALLOW copy: " + this.toString());
		return (StudentPrototype) this.clone();
	}

	@Override
	public StudentPrototype deepCopy() throws CloneNotSupportedException {
		System.out.println("Making GROUP deep copy: " + this.toString());

		try {
			ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
			ObjectOutputStream outputStrm = new ObjectOutputStream(outputStream);
			outputStrm.writeObject(this);

			ByteArrayInputStream inputStream = new ByteArrayInputStream(outputStream.toByteArray());
			ObjectInputStream objInputStream = new ObjectInputStream(inputStream);

			try {
				return (StudentPrototype) objInputStream.readObject();
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
				return null;
			}

		} catch (IOException e) {
			e.printStackTrace();
			return null;
		}

	}

}
