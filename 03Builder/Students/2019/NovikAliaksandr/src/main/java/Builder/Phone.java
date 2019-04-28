package Builder;

import ug.anovik.NovikAliaksandr.FluentBuilder.Battery;
import ug.anovik.NovikAliaksandr.FluentBuilder.CPU;
import ug.anovik.NovikAliaksandr.FluentBuilder.Camera;
import ug.anovik.NovikAliaksandr.FluentBuilder.ChargeSocket;
import ug.anovik.NovikAliaksandr.FluentBuilder.RAM;
import ug.anovik.NovikAliaksandr.FluentBuilder.Screen;

public class Phone {

	private CPU cpu;
	private Screen screen;
	private Battery battery;
	private RAM ram;
	private ChargeSocket socket;
	private Camera camera;

	public CPU getCpu() {
		return cpu;
	}

	public void setCpu(CPU cpu) {
		this.cpu = cpu;
	}

	public Screen getScreen() {
		return screen;
	}

	public void setScreen(Screen screen) {
		this.screen = screen;
	}

	public Battery getBattery() {
		return battery;
	}

	public void setBattery(Battery battery) {
		this.battery = battery;
	}

	public RAM getRam() {
		return ram;
	}

	public void setRam(RAM ram) {
		this.ram = ram;
	}

	public ChargeSocket getSocket() {
		return socket;
	}

	public void setSocket(ChargeSocket socket) {
		this.socket = socket;
	}

	public Camera getCamera() {
		return camera;
	}

	public void setCamera(Camera camera) {
		this.camera = camera;
	}

	@Override
	public String toString() {
		return "Phone [cpu=" + cpu + ", screen=" + screen + ", battery=" + battery + ", ram=" + ram + ", socket="
				+ socket + ", camera=" + camera + "]";
	}

}
