package smartphones.samsung;

import smartphones.Smartphone;

public class SamsungBudgetary extends Smartphone {

	public SamsungBudgetary() {
		this.model = "Galaxy M 20";
		this.display = 6.3d;
		this.proc = "Exynos 7904";
		this.battery = 5000;
	}

	@Override
	public String toString() {
		return "SamsungBudgetary [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery
				+ "]";
	}

}
