package FactoryVsBuilder;

import java.math.BigDecimal;

public class HuaweiFold extends Phone{

	public HuaweiFold() {
		this.phoneType = PhoneType.FOLD;
	}

	@Override
	public String toString() {
		return "HuaweiFold [phoneType=" + phoneType + "]";
	}

	
}
