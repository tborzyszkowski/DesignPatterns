package prototype;

import java.util.List;

public class Student extends StudentPrototype implements Cloneable {

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

}
