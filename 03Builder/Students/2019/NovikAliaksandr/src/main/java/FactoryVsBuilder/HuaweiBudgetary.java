package FactoryVsBuilder;

import java.math.BigDecimal;

public class HuaweiBudgetary extends Phone {

	public HuaweiBudgetary() {
		this.phoneType = PhoneType.BUDGETARY;
	}

	@Override
	public String toString() {
		return "HuaweiBudgetary [phoneType=" + phoneType + "]";
	}
	
}
