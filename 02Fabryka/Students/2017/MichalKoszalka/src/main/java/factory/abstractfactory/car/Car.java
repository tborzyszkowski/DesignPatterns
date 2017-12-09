package factory.abstractfactory.car;

import factory.abstractfactory.parts.body.Body;
import factory.abstractfactory.parts.chassis.Chassis;
import factory.abstractfactory.parts.drive.Drive;
import factory.abstractfactory.parts.engine.Engine;
import factory.abstractfactory.parts.turbocharger.TurboCharger;

public abstract class Car {

	String model;

	Engine engine;
	Body body;
	Chassis chassis;
	Drive drive;
	TurboCharger turboCharger;

	public abstract void prepare();

	public void setModel(String model) {
		this.model = model;
	}


	public String getModel() {
		return model;
	}

	public void refuel() {
		System.out.println("refueling car");
	}

	public void prepareTires() {
		System.out.println("prepare both winter and summer tires");
	}

	public String toString() {
		StringBuffer result = new StringBuffer();
		result.append(model);
		if (body != null) {
			result.append(body);
			result.append("\n");
		}
		if (engine != null) {
			result.append(engine);
			result.append("\n");
		}
		if (chassis != null) {
			result.append(chassis);
			result.append("\n");
		}
		if (drive != null) {
			result.append(drive);
			result.append("\n");
		}
		if (turboCharger != null) {
			result.append(turboCharger);
			result.append("\n");
		}
		return result.toString();
	}

}
