package registration.noReflection;

import java.lang.reflect.InvocationTargetException;

import registration.reflection.RefPhoneFactory;

public class Main {
	public static void main(String[] s) throws NoSuchMethodException, SecurityException, InstantiationException, IllegalAccessException, IllegalArgumentException, InvocationTargetException {
		RPhoneFactory pf = RPhoneFactory.getInstance();
		RSmartphone rHuaweiGaming = pf.createProduct("rHuaweiFoldId");
		RSmartphone rHuaweiFold = pf.createProduct("rHuaweiFoldId");
		
		RefPhoneFactory rpf = RefPhoneFactory.getInstance();
		rpf.initFactory();
		RSmartphone huaweiGaming = rpf.createProduct("rHuaweiFoldId");
	}
}
