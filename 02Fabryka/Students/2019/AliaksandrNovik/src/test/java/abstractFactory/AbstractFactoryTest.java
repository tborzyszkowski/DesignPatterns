package abstractFactory;

import org.junit.Before;
import org.junit.Test;

import abstractFactory.samsung.SamsungPhoneFactory;
import abstractFactory.xiaomi.XiaomiPhoneFactory;

public class AbstractFactoryTest {

	private PhoneFactory samsungPhone;
	private PhoneFactory xiaomiPhone;
	
	@Before
	public void beforeEach() {
		samsungPhone = SamsungPhoneFactory.getInstance();
		xiaomiPhone = XiaomiPhoneFactory.getInstance();
	}
	
	@Test
	public void samsungAbstractFactoryTest() {
		ITestService testService = samsungPhone.getTestService();
		IBoxService boxService = samsungPhone.getBoxService();
		
		testService.batteryLifeTest();
		testService.crashTest();
		testService.stressTest();
		boxService.pack();
	}
	
	@Test
	public void xiaomiAbstractFactoryTest() {
		ITestService testService = xiaomiPhone.getTestService();
		IBoxService boxService = xiaomiPhone.getBoxService();
		
		testService.batteryLifeTest();
		testService.crashTest();
		testService.stressTest();
		boxService.pack();
		
	}
	
}
