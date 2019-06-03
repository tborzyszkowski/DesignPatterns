package ug.anovik.dp;

import java.util.List;

public interface MobileDevice {

	public String getCpu();
	public double getScreenSize();
	public int getBatteryCapacity();
	public Memory getMemory();
	public List<Camera> getCameras();
	
}
