package ug.anovik.dp;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.List;
import java.util.stream.Collectors;

public class Tablet implements MobileDevice, Cloneable, Serializable {

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

	public Tablet(Tablet tablet) throws CloneNotSupportedException {
		this(tablet.getCpu(), tablet.getScreenSize(), tablet.getBatteryCapacity(), tablet.getMemory(),
				tablet.getAllCameras(tablet));
	}

	private List<Camera> getAllCameras(Tablet tablet) throws CloneNotSupportedException {
		return tablet.getCameras().stream().map(c -> new Camera(c.getMp(), c.getfNumber(), c.getPhotoType()))
				.collect(Collectors.toList());
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

	@Override
	public MobileDevice shallowCopy() throws CloneNotSupportedException {
		System.out.println("Making TABLET SWALLOW copy");
		return (MobileDevice) this.clone();
	}

	@Override
	public MobileDevice deepCopy() throws CloneNotSupportedException {
		System.out.println("Making TABLET DEEP copy");
		try {
			ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
			ObjectOutputStream outputStrm = new ObjectOutputStream(outputStream);
			outputStrm.writeObject(this);
			ByteArrayInputStream inputStream = new ByteArrayInputStream(outputStream.toByteArray());
			ObjectInputStream objectInputStream = new ObjectInputStream(inputStream);
			try {
				return (MobileDevice) objectInputStream.readObject();
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
				return null;
			}
		} catch (IOException e) {
			e.printStackTrace();
			return null;
		}
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + batteryCapacity;
		result = prime * result + ((cameras == null) ? 0 : cameras.hashCode());
		result = prime * result + ((cpu == null) ? 0 : cpu.hashCode());
		result = prime * result + ((memory == null) ? 0 : memory.hashCode());
		long temp;
		temp = Double.doubleToLongBits(screenSize);
		result = prime * result + (int) (temp ^ (temp >>> 32));
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Tablet other = (Tablet) obj;
		if (batteryCapacity != other.batteryCapacity)
			return false;
		if (cameras == null) {
			if (other.cameras != null)
				return false;
		} else if (!cameras.equals(other.cameras))
			return false;
		if (cpu == null) {
			if (other.cpu != null)
				return false;
		} else if (!cpu.equals(other.cpu))
			return false;
		if (memory == null) {
			if (other.memory != null)
				return false;
		} else if (!memory.equals(other.memory))
			return false;
		if (Double.doubleToLongBits(screenSize) != Double.doubleToLongBits(other.screenSize))
			return false;
		return true;
	}
	
	
}
