package smartphones.huawei;

import smartphones.Smartphone;

public class HuaweiBudgetary extends Smartphone {

	public HuaweiBudgetary() {
		this.model = "Y3 2018";
		this.display = 5.0d;
		this.proc = "Quad-core 1.1 GHz Cortex-A53";
		this.battery = 2280;
	}

	@Override
	public String toString() {
		return "HuaweiBudgetary [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery
				+ "]";
	}

}