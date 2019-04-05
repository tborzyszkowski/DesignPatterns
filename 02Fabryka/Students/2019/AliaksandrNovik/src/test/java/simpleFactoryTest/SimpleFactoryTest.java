package simpleFactoryTest;

import org.junit.Test;

import phoneTypes.PhoneType;
import simpleFactory.SimpleHuaweiFactory;
import smartphones.Smartphone;

public class SimpleFactoryTest {

	@Test
	public void huaweiSimpleFactoryTest() {
		SimpleHuaweiFactory simpleHuaweiFactory = SimpleHuaweiFactory.getInstance();
		Smartphone gaming = simpleHuaweiFactory.buildSmartphone(PhoneType.GAMING);
		Smartphone budgetary = simpleHuaweiFactory.buildSmartphone(PhoneType.BUDGETARY);
		Smartphone fold = simpleHuaweiFactory.buildSmartphone(PhoneType.FOLD);
		
		System.out.println(gaming.toString());
		System.out.println(budgetary.toString());
		System.out.println(fold.toString());

	}
}