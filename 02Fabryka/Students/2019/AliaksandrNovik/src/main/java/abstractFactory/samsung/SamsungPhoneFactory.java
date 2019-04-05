package abstractFactory.samsung;

import abstractFactory.IBoxService;
import abstractFactory.ITestService;
import abstractFactory.PhoneFactory;

public class SamsungPhoneFactory extends PhoneFactory{
	
	private static SamsungPhoneFactory INSTANCE;
	
	public static SamsungPhoneFactory getInstance() {
		if(INSTANCE == null) {
			INSTANCE = new SamsungPhoneFactory();
		}
		return INSTANCE;
	}

	@Override
	public ITestService getTestService() {
		return new SamsungTestService();
	}

	@Override
	public IBoxService getBoxService() {
		return new SamsungBoxService();
	}

}
