package FactoryVsBuilder;

import java.math.BigDecimal;

public class NewHuaweiGaming extends NewPhone{

	public NewHuaweiGaming() {
		this.phoneType = PhoneType.GAMING;
		this.price = new BigDecimal(99.99);
		this.model = new String("G");
	}
	
}
