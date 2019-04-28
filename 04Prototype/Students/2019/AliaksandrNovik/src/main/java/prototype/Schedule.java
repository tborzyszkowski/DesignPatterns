package prototype;

import java.util.List;

public class Schedule extends SchedulePrototype implements Cloneable {

	private int year;
	private int semester;
	private List<Group> groups;

	public Schedule(int year, int semester, List<Group> groups) {
		this.year = year;
		this.semester = semester;
		this.groups = groups;
	}

	public int getYear() {
		return year;
	}

	public void setYear(int year) {
		this.year = year;
	}

	public int getSemester() {
		return semester;
	}

	public void setSemester(int semester) {
		this.semester = semester;
	}

	public List<Group> getGroups() {
		return groups;
	}

	public void setGroups(List<Group> groups) {
		this.groups = groups;
	}

	@Override
	public String toString() {
		return "Schedule [year=" + year + ", semester=" + semester + ", groups=" + groups + "]";
	}

	@Override
	public SchedulePrototype shallowCopy() throws CloneNotSupportedException {
		System.out.println("Making SchedulePrototype swallow copy: " + this.toString());
		return (SchedulePrototype) this.clone();
	}

}
