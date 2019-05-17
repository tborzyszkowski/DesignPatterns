package FactoryVsBuilder;

import java.math.BigDecimal;

public class NewHuaweiBudgetary extends NewPhone {

	public NewHuaweiBudgetary() {
		this.phoneType = PhoneType.BUDGETARY;
		this.price = new BigDecimal(99.99);
		this.model = new String("B");
	}

}
