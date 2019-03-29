package fabricMethodsFactories;

import phoneTypes.PhoneType;
import smartphones.Smartphone;
import smartphones.xiaomi.XiaomiBudgetary;
import smartphones.xiaomi.XiaomiFold;
import smartphones.xiaomi.XiaomiGaming;

public class XiaomiPhoneFactory extends PhoneFactory{

	private static XiaomiPhoneFactory INSTANCE;
	
	public static XiaomiPhoneFactory getInstance() {
		if(INSTANCE == null) {
			INSTANCE = new XiaomiPhoneFactory();
		}
		return INSTANCE;
	}
	
	@Override
	public Smartphone createSmartphone(PhoneType phoneType) {
		if (phoneType.equals(PhoneType.GAMING)) {
			return new XiaomiGaming();
		} else if (phoneType.equals(PhoneType.BUDGETARY)) {
			return new XiaomiBudgetary();
		} else if (phoneType.equals(PhoneType.FOLD)) {
			return new XiaomiFold();
		} else {
			return null;
		}
	}

}
