package FactoryVsBuilder;

import java.math.BigDecimal;

public class NewHuaweiFold extends NewPhone {

	public NewHuaweiFold() {
		this.phoneType = PhoneType.FOLD;
		this.price = new BigDecimal(99.99);
		this.model = new String("F");
	}

}
