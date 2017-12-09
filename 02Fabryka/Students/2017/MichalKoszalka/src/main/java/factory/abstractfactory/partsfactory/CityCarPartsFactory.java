package factory.abstractfactory.partsfactory;

import factory.abstractfactory.parts.body.Body;
import factory.abstractfactory.parts.body.HatchbackBody;
import factory.abstractfactory.parts.chassis.Chassis;
import factory.abstractfactory.parts.chassis.LowChassis;
import factory.abstractfactory.parts.drive.Drive;
import factory.abstractfactory.parts.drive.FrontWheelDrive;
import factory.abstractfactory.parts.engine.ElectricEngine;
import factory.abstractfactory.parts.engine.Engine;
import factory.abstractfactory.parts.turbocharger.TurboCharger;

public class CityCarPartsFactory implements CarPartsAbstractFactory {

	@Override
	public Engine createEngine() {
		return new ElectricEngine();
	}

	@Override
	public Chassis createChassis() {
		return new LowChassis();
	}

	@Override
	public Body createBody() {
		return new HatchbackBody();
	}

	@Override
	public Drive createDrive() {
		return new FrontWheelDrive();
	}

	@Override
	public TurboCharger createTurboCharger() {
		return null;
	}

}
