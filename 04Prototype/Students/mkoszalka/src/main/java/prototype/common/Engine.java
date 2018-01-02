package prototype.common;

import java.io.Serializable;

public class Engine implements Serializable {

	private static final long serialVersionUID = -4309681104782225074L;

	FuelType fuelType;

	public Engine(FuelType fuelType) {
		this.fuelType = fuelType;
	}

	public Engine(Engine engine) {
		fuelType = engine.fuelType;
	}

	public FuelType getFuelType() {
		return fuelType;
	}

	public void setFuelType(FuelType fuelType) {
		this.fuelType = fuelType;
	}
}
