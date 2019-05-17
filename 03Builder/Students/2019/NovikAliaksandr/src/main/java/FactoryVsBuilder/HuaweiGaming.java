package FactoryVsBuilder;


public class HuaweiGaming extends Phone {

	public HuaweiGaming() {
		this.phoneType = PhoneType.GAMING;
	}

	@Override
	public String toString() {
		return "HuaweiGaming [phoneType=" + phoneType + "]";
	}

}
