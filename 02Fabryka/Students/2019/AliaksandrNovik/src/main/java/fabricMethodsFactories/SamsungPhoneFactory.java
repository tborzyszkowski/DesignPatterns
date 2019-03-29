package fabricMethodsFactories;

import phoneTypes.PhoneType;
import smartphones.Smartphone;
import smartphones.samsung.SamsungBudgetary;
import smartphones.samsung.SamsungFold;
import smartphones.samsung.SamsungGaming;

public class SamsungPhoneFactory extends PhoneFactory {

	private static SamsungPhoneFactory INSTANCE;

	public static SamsungPhoneFactory getInstance() {
		if (INSTANCE == null) {
			INSTANCE = new SamsungPhoneFactory();
		}
		return INSTANCE;
	}

	@Override
	public Smartphone createSmartphone(PhoneType phoneType) {
		if (phoneType.equals(PhoneType.GAMING)) {
			return new SamsungGaming();
		} else if (phoneType.equals(PhoneType.BUDGETARY)) {
			return new SamsungBudgetary();
		} else if (phoneType.equals(PhoneType.FOLD)) {
			return new SamsungFold();
		} else {
			return null;
		}
	}

}
