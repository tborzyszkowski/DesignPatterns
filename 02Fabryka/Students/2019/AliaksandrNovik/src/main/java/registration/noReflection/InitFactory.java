package registration.noReflection;

import registration.noReflection.smartphones.RHuaweiFold;
import registration.noReflection.smartphones.RHuaweiGaming;

public class InitFactory {
	
	public static void initFactory(String idProduct) {

		RPhoneFactory pf = RPhoneFactory.getInstance();

		if (pf.getRegistredProducts().get(idProduct) == null) {
			if (idProduct.equals("rHuaweiGamingId")) {

				pf.getRegistredProducts().put(idProduct, new RHuaweiGaming());

			} else if (idProduct.equals("rHuaweiFoldId")) {

				pf.getRegistredProducts().put(idProduct, new RHuaweiFold());
			}

		}

	}

}
