package smartphones.huawei;

import smartphones.Smartphone;

public class HuaweiFold extends Smartphone {

	public HuaweiFold() {
		this.model = "Mate X";
		this.display = 7.3d;
		this.proc = "Kirin 980";
		this.battery = 4500;
	}

	@Override
	public String toString() {
		return "HuaweiFold [model=" + model + ", display=" + display + ", proc=" + proc + ", battery=" + battery + "]";
	}
}