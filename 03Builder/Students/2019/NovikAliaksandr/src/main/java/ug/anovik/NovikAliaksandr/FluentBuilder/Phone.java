package ug.anovik.NovikAliaksandr.FluentBuilder;

public class Phone {
	
	private CPU cpu;
	private Screen screen;
	private Battery battery;
	private RAM ram;
	private ChargeSocket socket;
	private Camera camera;
	
	public Phone cpu(CPU cpu) {
		this.cpu = cpu;
		return this;
	}

	public Phone screen(Screen screen) {
		this.screen = screen;
		return this;
	}

	public Phone battery(Battery battery) {
		this.battery = battery;
		return this;
	}

	public Phone ram(RAM ram) {
		this.ram = ram;
		return this;
	}

	public Phone socket(ChargeSocket socket) {
		this.socket = socket;
		return this;
	}
	
	public Phone camera(Camera camera) {
		this.camera =  camera;
		return this;
	}

	@Override
	public String toString() {
		return "Phone [cpu=" + cpu + ", screen=" + screen + ", battery=" + battery + ", ram=" + ram + ", socket="
				+ socket + ", camera=" + camera + "]";
	}
	
	

}
