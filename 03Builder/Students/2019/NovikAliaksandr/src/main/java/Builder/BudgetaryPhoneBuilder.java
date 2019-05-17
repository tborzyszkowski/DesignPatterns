package Builder;

import ug.anovik.NovikAliaksandr.FluentBuilder.Battery;
import ug.anovik.NovikAliaksandr.FluentBuilder.CPU;
import ug.anovik.NovikAliaksandr.FluentBuilder.Camera;
import ug.anovik.NovikAliaksandr.FluentBuilder.ChargeSocket;
import ug.anovik.NovikAliaksandr.FluentBuilder.RAM;
import ug.anovik.NovikAliaksandr.FluentBuilder.Screen;

public class BudgetaryPhoneBuilder {

	PhoneBuilder builder;
	
	public BudgetaryPhoneBuilder(PhoneBuilder builder) {
		this.builder = builder;
	}
	
	public void buildPhone() {
		builder.setBattery(Battery.LITHIUM_POL);
		builder.setCamera(new Camera(2,"24"));
		builder.setCPU(new CPU(2,"1,9"));
		builder.setRAM(RAM.TWO_GB);
		builder.setScreen(Screen.IPS);
		builder.setSocket(ChargeSocket.MINI_USB);
	}
	
	public Phone getPhone() {
		buildPhone();
		return builder.buildPhone();
	}
}
