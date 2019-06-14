package ug.anovik.dp.facade;

import java.util.Arrays;
import java.util.List;

import ug.anovik.dp.Camera;
import ug.anovik.dp.Manager;
import ug.anovik.dp.Memory;
import ug.anovik.dp.MobileDevice;
import ug.anovik.dp.MobileDeviceFactory;
import ug.anovik.dp.Phone;
import ug.anovik.dp.PhoneFactory;
import ug.anovik.dp.PhotoType;
import ug.anovik.dp.Tablet;

public class MobileDeviceFacade {

	static Manager<String, MobileDevice> manager = new Manager<>();

	
	static {

		List<Camera> cameras = Arrays.asList(new Camera(24, 2.0, PhotoType.WIDE),
				new Camera(48, 2.4, PhotoType.ULTRAWIDE), new Camera(12, 1.6, PhotoType.TELEPHOTO));
		MobileDevice phone = MobileDeviceFactory
				.getMobileDevice(new PhoneFactory("Snapdragon 858", 6.1d, 4100, new Memory(128, 4, true), cameras));
		manager.addDevice("Samsung Galxy S9", phone);

		List<Camera> cameras2 = Arrays.asList(new Camera(28, 2.0, PhotoType.WIDE),
				new Camera(48, 2.4, PhotoType.ULTRAWIDE), new Camera(16, 1.6, PhotoType.TELEPHOTO));
		MobileDevice phone2 = MobileDeviceFactory
				.getMobileDevice(new PhoneFactory("Snapdragon 858", 6.2d, 4200, new Memory(256, 6, true), cameras2));
		manager.addDevice("Samsung Galxy S10", phone2);

	}

	public static Manager<String, MobileDevice> getManager() {
		return manager;
	}

	public static Phone clonePhone(String model) throws CloneNotSupportedException {
		return (Phone) manager.getDevice(model).shallowCopy();
	}

	public static Tablet cloneTablet(String model) throws CloneNotSupportedException {
		return (Tablet) manager.getDevice(model).shallowCopy();
	}

}
