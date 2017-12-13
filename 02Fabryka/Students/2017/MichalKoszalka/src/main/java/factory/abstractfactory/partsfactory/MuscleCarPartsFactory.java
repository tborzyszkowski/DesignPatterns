package factory.abstractfactory.partsfactory;

import factory.abstractfactory.parts.body.Body;
import factory.abstractfactory.parts.body.SedanBody;
import factory.abstractfactory.parts.chassis.Chassis;
import factory.abstractfactory.parts.chassis.LowChassis;
import factory.abstractfactory.parts.drive.Drive;
import factory.abstractfactory.parts.drive.RearWheelDrive;
import factory.abstractfactory.parts.engine.Engine;
import factory.abstractfactory.parts.engine.GasolineEngine;
import factory.abstractfactory.parts.turbocharger.TurboCharger;
import factory.abstractfactory.parts.turbocharger.TwinTurboCharger;

public class MuscleCarPartsFactory implements CarPartsAbstractFactory {

	@Override
	public Engine createEngine() {
		return new GasolineEngine();
	}

	@Override
	public Chassis createChassis() {
		return new LowChassis();
	}

	@Override
	public Body createBody() {
		return new SedanBody();
	}

	@Override
	public Drive createDrive() {
		return new RearWheelDrive();
	}

	@Override
	public TurboCharger createTurboCharger() {
		return new TwinTurboCharger();
	}

}
