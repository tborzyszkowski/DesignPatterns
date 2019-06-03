package ug.anovik.dp;

import java.util.List;

public class Tablet implements MobileDevice {

	private String cpu;
	private double screenSize;
	private int batteryCapacity;
	private Memory memory;
	private List<Camera> cameras;

	public Tablet(String cpu, double screenSize, int batteryCapacity, Memory memory, List<Camera> cameras) {
		super();
		this.cpu = cpu;
		this.screenSize = screenSize;
		this.batteryCapacity = batteryCapacity;
		this.memory = memory;
		this.cameras = cameras;
	}

	public String getCpu() {
		return cpu;
	}

	public double getScreenSize() {
		return screenSize;
	}

	public int getBatteryCapacity() {
		return batteryCapacity;
	}

	public Memory getMemory() {
		return memory;
	}

	public List<Camera> getCameras() {
		return cameras;
	}

	@Override
	public String toString() {
		return "Tablet [cpu=" + cpu + ", screenSize=" + screenSize + ", batteryCapacity=" + batteryCapacity
				+ ", memory=" + memory + ", cameras=" + cameras + "]";
	}
}
