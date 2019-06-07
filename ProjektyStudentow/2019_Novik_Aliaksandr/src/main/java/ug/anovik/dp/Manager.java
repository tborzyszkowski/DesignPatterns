package ug.anovik.dp;

import java.util.HashMap;
import java.util.Map;

public class Manager<K, V> {
	private Map<K,V> devices;
	
	public Manager() {
		this.devices = new HashMap<>();
	}
	
	public V getDevice(K model) {
		return devices.get(model);
	}
	
	public void addDevice(K model, V value) {
		devices.put(model, value);
	}
	
	public Map<K,V> getDevices(){
		return devices;
	}
}
