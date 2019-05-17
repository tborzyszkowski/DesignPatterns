package prototype;

import java.util.List;
import java.util.stream.Collectors;


public class Schedule extends SchedulePrototype implements Cloneable {

	private int year;
	private int semester;
	private List<GroupPrototype> groups;

	public Schedule(int year, int semester, List<GroupPrototype> groups) {
		this.year = year;
		this.semester = semester;
		this.groups = groups;
	}

	public Schedule(Schedule schedule) {
		this(schedule.getYear(), schedule.getSemester(), schedule.getAllGrousp(schedule));
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

	public List<GroupPrototype> getGroups() {
		return groups;
	}

	public void setGroups(List<GroupPrototype> groups) {
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

	@Override
	public SchedulePrototype deepCopy() throws CloneNotSupportedException {
		System.out.println("Making SchedulePrototype deep copy: " + this.toString());
		return (SchedulePrototype) new Schedule(this);
	}

	private List<GroupPrototype> getAllGrousp(Schedule schedule) {
		return schedule.getGroups().stream().map(g -> {
			try {
				return g.deepCopy();
			} catch (CloneNotSupportedException e) {
				e.printStackTrace();
			}
			return null;
		}).collect(Collectors.toList());

	}
}
