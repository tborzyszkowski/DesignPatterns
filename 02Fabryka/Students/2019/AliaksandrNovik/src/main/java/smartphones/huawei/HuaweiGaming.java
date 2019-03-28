package smartphones.huawei;

import smartphones.Smartphone;

public class HuaweiGaming extends Smartphone {

	public HuaweiGaming() {
		this.model = "Mate 20 Pro";
		this.display = 6.39d;
		this.proc = "Kirin 980";
		this.battery = 4200;
	}

	@Override
	public String toString() {
		return "HuaweiGaming [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery
				+ "]";
	}

}