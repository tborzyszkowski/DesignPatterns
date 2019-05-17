package FactoryVsBuilder.factory;

import FactoryVsBuilder.NewHuaweiBudgetary;
import FactoryVsBuilder.NewHuaweiFold;
import FactoryVsBuilder.NewHuaweiGaming;
import FactoryVsBuilder.NewPhone;
import FactoryVsBuilder.PhoneType;

public class NewSimplePhoneFactory {
	private static NewSimplePhoneFactory INSTANCE;

	public static NewSimplePhoneFactory getInstance() {
		if (INSTANCE == null) {
			INSTANCE = new NewSimplePhoneFactory();
		}
		return INSTANCE;
	}
	
	public NewPhone buildPhone(PhoneType type) {
		if(type.equals(PhoneType.GAMING)) {
			return new NewHuaweiGaming();
		}else if(type.equals(PhoneType.BUDGETARY)) {
			return new NewHuaweiBudgetary();
		}else if(type.equals(PhoneType.FOLD)) {
			return new NewHuaweiFold();
		}
		return null;
	}

}
