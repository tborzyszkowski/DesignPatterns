package classRegistration;

import java.lang.reflect.InvocationTargetException;
import java.util.HashSet;
import java.util.Set;

import org.junit.Test;

import phoneTypes.PhoneType;
import registration.noReflection.RPhoneFactory;
import registration.noReflection.RSmartphone;
import registration.reflection.RefPhoneFactory;
import simpleFactory.SimpleHuaweiFactory;
import smartphones.Smartphone;

public class ClassRegistrationTest {

	@Test
	public void classRegistrationTimeTest() {

		Set<RSmartphone> rHuaweiGaming = new HashSet<>();
		RPhoneFactory pf = RPhoneFactory.getInstance();

		for (int i = 0; i < 1000000; i++) {
			rHuaweiGaming.add(pf.createProduct("rHuaweiGamingId"));

		}
	}

	@Test
	public void simpleFactoryTimeTest() {

		Set<Smartphone> huaweiGaming = new HashSet<>();
		SimpleHuaweiFactory simpleHuaweiFactory = SimpleHuaweiFactory.getInstance();

		for (int i = 0; i < 1000000; i++) {
			huaweiGaming.add(simpleHuaweiFactory.buildSmartphone(PhoneType.GAMING));
		}
	}

	@Test
	public void classRegReflectionTimeTest() throws NoSuchMethodException, SecurityException, InstantiationException,
			IllegalAccessException, IllegalArgumentException, InvocationTargetException {

		Set<RSmartphone> rHuaweiGaming = new HashSet<>();
		RefPhoneFactory rpf = RefPhoneFactory.getInstance();
		rpf.initFactory();

		for (int i = 0; i < 1000000; i++) {
			rHuaweiGaming.add(rpf.createProduct("rHuaweiFoldId"));
		}
	}

}
