package smartphones.xiaomi;

import smartphones.Smartphone;

public class XiaomiBudgetary extends Smartphone {

	public XiaomiBudgetary() {
		this.model = "Mi Mix 2S";
		this.display = 5.99d;
		this.proc = "Snapdragon 845";
		this.battery = 3400;
	}

	@Override
	public String toString() {
		return "XiaomiBudgetary [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery
				+ "]";
	}
}