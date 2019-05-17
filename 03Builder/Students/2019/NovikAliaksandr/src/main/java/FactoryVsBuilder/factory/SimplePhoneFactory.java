package FactoryVsBuilder.factory;

import FactoryVsBuilder.HuaweiBudgetary;
import FactoryVsBuilder.HuaweiFold;
import FactoryVsBuilder.HuaweiGaming;
import FactoryVsBuilder.Phone;
import FactoryVsBuilder.PhoneType;

public class SimplePhoneFactory {

	private static SimplePhoneFactory INSTANCE;

	public static SimplePhoneFactory getInstance() {
		if (INSTANCE == null) {
			INSTANCE = new SimplePhoneFactory();
		}
		return INSTANCE;
	}

	public Phone buildPhone(PhoneType type) {
		if (type.equals(PhoneType.GAMING)) {
			return new HuaweiGaming();
		} else if (type.equals(PhoneType.BUDGETARY)) {
			return new HuaweiBudgetary();
		} else if (type.equals(PhoneType.FOLD)) {
			return new HuaweiFold();
		}
		return null;
	}

}
