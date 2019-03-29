package fabricMethodFactoriesTest;

import org.junit.Before;
import org.junit.Test;

import fabricMethodsFactories.HuaweiPhoneFactory;
import fabricMethodsFactories.PhoneFactory;
import fabricMethodsFactories.SamsungPhoneFactory;
import fabricMethodsFactories.XiaomiPhoneFactory;
import phoneTypes.PhoneType;

public class FabricMethodFactoriesTest {

	private PhoneFactory samsungPhone;
	private PhoneFactory huaweiPhone;
	private PhoneFactory xiaomiPhone;
	
	@Before
	public void beforeEach() {
		samsungPhone = SamsungPhoneFactory.getInstance();
		huaweiPhone = HuaweiPhoneFactory.getInstance();
		xiaomiPhone = XiaomiPhoneFactory.getInstance();
	}
	
	@Test
	public void samsungFabricMethodFactoriesTest() {
		
		System.out.println(samsungPhone.createSmartphone(PhoneType.GAMING).toString());
		System.out.println(samsungPhone.createSmartphone(PhoneType.BUDGETARY).toString());
		System.out.println(samsungPhone.createSmartphone(PhoneType.FOLD).toString());
		System.out.println();
	}
	
	@Test
	public void huaweiFabricMethodFactoriesTest() {
		
		System.out.println(huaweiPhone.createSmartphone(PhoneType.GAMING).toString());
		System.out.println(huaweiPhone.createSmartphone(PhoneType.BUDGETARY).toString());
		System.out.println(huaweiPhone.createSmartphone(PhoneType.FOLD).toString());
		System.out.println();
	}
	
	@Test
	public void xiaomiFabricMethodFactoriesTest() {
		
		System.out.println(xiaomiPhone.createSmartphone(PhoneType.GAMING).toString());
		System.out.println(xiaomiPhone.createSmartphone(PhoneType.BUDGETARY).toString());
		System.out.println(xiaomiPhone.createSmartphone(PhoneType.FOLD).toString());
		System.out.println();
	}


}
