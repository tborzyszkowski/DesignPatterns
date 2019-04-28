package prototype;

import java.util.HashMap;
import java.util.Map;

public class ScheduleManager {
	private Map<String, SchedulePrototype> schedules;
	
	public ScheduleManager() {
		this.schedules = new HashMap<>();
	}
	
	public SchedulePrototype getGroup(String key) {
		return schedules.get(key);
	}
	
	public void addSchedule(String key, SchedulePrototype value) {
		schedules.put(key, value);
	}
	
	public Map<String, SchedulePrototype> getGroups(){
		return schedules;
	}

}
