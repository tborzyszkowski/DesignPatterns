package prototype;

import java.util.HashMap;
import java.util.Map;

public class GroupManager {
	private Map<String, GroupPrototype> groups;
	
	public GroupManager() {
		this.groups = new HashMap<>();
	}
	
	public GroupPrototype getGroup(String key) {
		return groups.get(key);
	}
	
	public void addGroup(String key, GroupPrototype value) {
		groups.put(key, value);
	}
	
	public Map<String, GroupPrototype> getGroups(){
		return groups;
	}

}
