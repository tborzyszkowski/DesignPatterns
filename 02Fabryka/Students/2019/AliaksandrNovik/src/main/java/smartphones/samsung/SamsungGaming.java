package smartphones.samsung;

import smartphones.Smartphone;

public class SamsungGaming extends Smartphone {

	public SamsungGaming() {
		this.model = "Galaxy Note 9";
		this.display = 6.4d;
		this.proc = "Snapdragon 845 / Exynos 9810";
		this.battery = 4000;
	}

	@Override
	public String toString() {
		return "SamsungGaming [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery
				+ "]";
	}

}