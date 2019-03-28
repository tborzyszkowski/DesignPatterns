package smartphones.xiaomi;

import smartphones.Smartphone;

public class XiaomiGaming extends Smartphone {

	public XiaomiGaming() {
		this.model = "Black Shark 2";
		this.display = 6.39d;
		this.proc = "Snapdragon 855";
		this.battery = 4000;
	}

	@Override
	public String toString() {
		return "XiaomiGaming [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery
				+ "]";
	}
}