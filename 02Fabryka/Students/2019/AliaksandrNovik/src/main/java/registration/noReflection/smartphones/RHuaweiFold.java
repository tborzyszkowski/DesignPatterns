package registration.noReflection.smartphones;

import registration.noReflection.RPhoneFactory;
import registration.noReflection.RSmartphone;

public class RHuaweiFold extends RSmartphone {

	public RHuaweiFold() {
		this.model = "Mate X";
		this.display = 7.3d;
		this.proc = "Kirin 980";
		this.battery = 4500;
	}

	private static RPhoneFactory pf;
	static {
		pf = RPhoneFactory.getInstance();
		pf.registerProduct("rHuaweiFoldId", new RHuaweiFold());
	}

	@Override
	public RSmartphone createPhone() {
		return new RHuaweiFold();
	}

}
