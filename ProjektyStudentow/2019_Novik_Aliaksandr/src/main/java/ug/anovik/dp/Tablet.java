package ug.anovik.dp;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.List;
import java.util.stream.Collectors;

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
}
