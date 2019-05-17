package prototype;

import java.util.HashMap;
import java.util.Map;

public class StudentManager {

	private Map<String, StudentPrototype> students;
	
	public StudentManager() {
		this.students = new HashMap<>();
	}
	
	public StudentPrototype getStudent(String key) {
		return students.get(key);
	}
	
	public void addStudent(String key, StudentPrototype value) {
		students.put(key, value);
	}
	
	public Map<String, StudentPrototype> getStudents(){
		return students;
	}
	
}
