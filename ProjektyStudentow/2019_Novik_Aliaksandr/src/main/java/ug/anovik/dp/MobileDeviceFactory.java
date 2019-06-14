package ug.anovik.dp;

public class MobileDeviceFactory {
	
	public static MobileDevice getMobileDevice(MobileDeviceAbstractFactory factory) {
		return factory.createMobileDevice();
	}

}
