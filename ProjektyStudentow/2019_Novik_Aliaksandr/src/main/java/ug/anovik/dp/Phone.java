package ug.anovik.dp;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.List;
import java.util.stream.Collectors;

public class Phone implements MobileDevice, Cloneable, Serializable {

	private static final long serialVersionUID = 1L;
	
	private String cpu;
	private double screenSize;
	private int batteryCapacity;
	private Memory memory;
	private List<Camera> cameras;

	public Phone(String cpu, double screenSize, int batteryCapacity, Memory memory, List<Camera> cameras) {
		super();
		this.cpu = cpu;
		this.screenSize = screenSize;
		this.batteryCapacity = batteryCapacity;
		this.memory = memory;
		this.cameras = cameras;
	}
	
	public Phone(Phone phone) throws CloneNotSupportedException{
		this(phone.getCpu(), phone.getScreenSize(), phone.getBatteryCapacity(), phone.getMemory(), phone.getAllCameras(phone));
	}

	private List<Camera> getAllCameras(Phone phone) throws CloneNotSupportedException {
		return phone.getCameras().stream()
				.map(c -> new Camera(c.getMp(), c.getfNumber(), c.getPhotoType())).collect(Collectors.toList());
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
		return "Phone [cpu=" + cpu + ", screenSize=" + screenSize + ", batteryCapacity=" + batteryCapacity + ", memory="
				+ memory + ", cameras=" + cameras + "]";
	}

	@Override
	public MobileDevice shallowCopy() throws CloneNotSupportedException {
		System.out.println("Making PHONE SWALLOW copy");
		return (MobileDevice) this.clone();
	}
	
	@Override
	public MobileDevice deepCopy() throws CloneNotSupportedException{
		System.out.println("Making PHONE DEEP copy");
		try {
			ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
			ObjectOutputStream outputStrm = new ObjectOutputStream(outputStream);
			outputStrm.writeObject(this);
			ByteArrayInputStream inputStream = new ByteArrayInputStream(outputStream.toByteArray());
			ObjectInputStream objectInputStream = new ObjectInputStream(inputStream);
			try {
				return (MobileDevice)objectInputStream.readObject();
			}catch(ClassNotFoundException e) {
				e.printStackTrace();
				return null;
			}
		}catch(IOException e) {
			e.printStackTrace();
			return null;
		}
	}

}
