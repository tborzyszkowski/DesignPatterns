package ug.anovik.dp;

import java.util.List;

public class PhoneFactory implements MobileDeviceAbstractFactory{

	private String cpu;
	private double screenSize;
	private int batteryCapacity;
	private Memory memory;
	private List<Camera> cameras;

	public PhoneFactory(String cpu, double screenSize, int batteryCapacity, Memory memory, List<Camera> cameras) {
		super();
		this.cpu = cpu;
		this.screenSize = screenSize;
		this.batteryCapacity = batteryCapacity;
		this.memory = memory;
		this.cameras = cameras;
	}

	@Override
	public MobileDevice createMobileDevice() {
		return new Phone(cpu, screenSize, batteryCapacity, memory, cameras);
	}

	
}
