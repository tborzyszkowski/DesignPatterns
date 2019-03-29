package fabricMethodsFactories;

import phoneTypes.PhoneType;
import smartphones.Smartphone;

public abstract class PhoneFactory {

	abstract Smartphone createSmartphone(PhoneType phoneType);
	
	public void orderSmartphone(PhoneType phoneType) {
		Smartphone phone = createSmartphone(phoneType);
		phone.phoneAssembling();
		phone.crashTest();
		phone.batteryLifeTest();
		phone.stressTest();
	}
	
}
