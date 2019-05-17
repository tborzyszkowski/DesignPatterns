package ug.anovik.NovikAliaksandr.FluentBuilder;

import org.junit.Test;

public class FluentBuilder {

	@Test
	public void buildPhone() {
		Phone phone = new Phone().screen(Screen.AMOLED).battery(Battery.LITHIUM_LON).camera(new Camera(4, "40"))
				.cpu(new CPU(4, "2,2")).ram(RAM.SIX_GB).socket(ChargeSocket.MINI_USB);
		System.out.println(phone);
	}
}
