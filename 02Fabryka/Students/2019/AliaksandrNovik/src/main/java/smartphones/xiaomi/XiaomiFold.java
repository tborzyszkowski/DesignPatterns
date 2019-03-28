package smartphones.xiaomi;

import smartphones.Smartphone;

public class XiaomiFold extends Smartphone {

	public XiaomiFold() {
		this.model = "Mi F 3s";
		this.display = 6.7d;
		this.proc = "Exynos 9810";
		this.battery = 4100;
	}

	@Override
	public String toString() {
		return "XiaomiFold [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery + "]";
	}
}