package smartphones.samsung;

import smartphones.Smartphone;

public class SamsungFold extends Smartphone {

	public SamsungFold() {
		this.model = "Galaxy Fold";
		this.display = 7.3d;
		this.proc = "7nm processor";
		this.battery = 4380;
	}

	@Override
	public String toString() {
		return "SamsungFold [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery + "]";
	}
}