package Builder;

import ug.anovik.NovikAliaksandr.FluentBuilder.Battery;
import ug.anovik.NovikAliaksandr.FluentBuilder.CPU;
import ug.anovik.NovikAliaksandr.FluentBuilder.Camera;
import ug.anovik.NovikAliaksandr.FluentBuilder.ChargeSocket;
import ug.anovik.NovikAliaksandr.FluentBuilder.RAM;
import ug.anovik.NovikAliaksandr.FluentBuilder.Screen;

public interface PhoneBuilder {
	
	public void setCPU(CPU cpu);
	public void setRAM(RAM ram);
	public void setCamera(Camera cam);
	public void setScreen(Screen scr);
	public void setSocket(ChargeSocket socket);
	public void setBattery(Battery battery);
	public Phone buildPhone();
}
