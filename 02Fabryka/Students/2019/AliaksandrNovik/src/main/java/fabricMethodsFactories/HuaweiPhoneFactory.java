package fabricMethodsFactories;

import phoneTypes.PhoneType;
import smartphones.Smartphone;
import smartphones.huawei.HuaweiBudgetary;
import smartphones.huawei.HuaweiFold;
import smartphones.huawei.HuaweiGaming;

public class HuaweiPhoneFactory extends PhoneFactory {

	private static HuaweiPhoneFactory INSTANCE;

	public static HuaweiPhoneFactory getInstance() {
		if (INSTANCE == null) {
			INSTANCE = new HuaweiPhoneFactory();
		}
		return INSTANCE;
	}

	@Override
	Smartphone createSmartphone(PhoneType phoneType) {
		if (phoneType.equals(PhoneType.GAMING)) {
			return new HuaweiGaming();
		} else if (phoneType.equals(PhoneType.BUDGETARY)) {
			return new HuaweiBudgetary();
		} else if (phoneType.equals(PhoneType.FOLD)) {
			return new HuaweiFold();
		} else {
			return null;
		}
	}

}
