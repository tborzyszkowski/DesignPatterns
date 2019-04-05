package abstractFactory.xiaomi;

import abstractFactory.IBoxService;
import abstractFactory.ITestService;
import abstractFactory.PhoneFactory;

public class XiaomiPhoneFactory extends PhoneFactory {
	
	private static XiaomiPhoneFactory INSTANCE;
	
	public static XiaomiPhoneFactory getInstance() {
		if(INSTANCE == null) {
			INSTANCE = new XiaomiPhoneFactory();
		}
		return INSTANCE;
	}

	@Override
	public ITestService getTestService() {
		return new XiaomiTestService();
	}

	@Override
	public IBoxService getBoxService() {
		return new XiaomiBoxService();
	}

}
