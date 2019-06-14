package ug.anovik.dp;

import java.util.List;

public interface MobileDevice {

	public abstract String getCpu();
	public abstract double getScreenSize();
	public abstract int getBatteryCapacity();
	public abstract Memory getMemory();
	public abstract List<Camera> getCameras();
	public abstract MobileDevice shallowCopy() throws CloneNotSupportedException;
	public abstract MobileDevice deepCopy() throws CloneNotSupportedException;
	
}
