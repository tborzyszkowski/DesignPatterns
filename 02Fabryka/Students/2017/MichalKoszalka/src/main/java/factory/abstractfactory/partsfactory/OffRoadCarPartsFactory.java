package factory.abstractfactory.partsfactory;

import factory.abstractfactory.parts.body.Body;
import factory.abstractfactory.parts.body.PickUpBody;
import factory.abstractfactory.parts.chassis.Chassis;
import factory.abstractfactory.parts.chassis.HighChassis;
import factory.abstractfactory.parts.drive.Drive;
import factory.abstractfactory.parts.drive.FourWheelDrive;
import factory.abstractfactory.parts.engine.Engine;
import factory.abstractfactory.parts.engine.OilEngine;
import factory.abstractfactory.parts.turbocharger.SingleTurboCharger;
import factory.abstractfactory.parts.turbocharger.TurboCharger;

public class OffRoadCarPartsFactory implements CarPartsAbstractFactory {

	@Override
	public Engine createEngine() {
		return new OilEngine();
	}

	@Override
	public Chassis createChassis() {
		return new HighChassis();
	}

	@Override
	public Body createBody() {
		return new PickUpBody();
	}

	@Override
	public Drive createDrive() {
		return new FourWheelDrive();
	}

	@Override
	public TurboCharger createTurboCharger() {
		return new SingleTurboCharger();
	}

}