package Builder;

import ug.anovik.NovikAliaksandr.FluentBuilder.Battery;
import ug.anovik.NovikAliaksandr.FluentBuilder.CPU;
import ug.anovik.NovikAliaksandr.FluentBuilder.Camera;
import ug.anovik.NovikAliaksandr.FluentBuilder.ChargeSocket;
import ug.anovik.NovikAliaksandr.FluentBuilder.RAM;
import ug.anovik.NovikAliaksandr.FluentBuilder.Screen;

public class PhoneBuilderImpl implements PhoneBuilder {

	private Phone phone;
	
	public PhoneBuilderImpl() {
		this.phone = new Phone();
	}
	
	@Override
	public void setCPU(CPU cpu) {
		this.phone.setCpu(cpu);
	}

	@Override
	public void setRAM(RAM ram) {
		this.phone.setRam(ram);
	}

	@Override
	public void setCamera(Camera cam) {
		this.phone.setCamera(cam);
	}

	@Override
	public void setScreen(Screen scr) {
		this.phone.setScreen(scr);
	}

	@Override
	public void setSocket(ChargeSocket socket) {
		this.phone.setSocket(socket);
	}

	@Override
	public void setBattery(Battery battery) {
		this.phone.setBattery(battery);
	}

	@Override
	public Phone buildPhone() {
		return this.phone;
	}

}
