package registration.noReflection.smartphones;

import registration.noReflection.RPhoneFactory;
import registration.noReflection.RSmartphone;

public class RHuaweiGaming extends RSmartphone {

	public RHuaweiGaming() {
		this.model = "Mate 20 Pro";
		this.display = 6.39d;
		this.proc = "Kirin 980";
		this.battery = 4200;
	}

	private static RPhoneFactory pf;
	static {
		pf = RPhoneFactory.getInstance();
		pf.registerProduct("rHuaweiGamingId", new RHuaweiGaming());
	}
	
	@Override
	public RSmartphone createPhone() {
		return new RHuaweiGaming();
	}
}
