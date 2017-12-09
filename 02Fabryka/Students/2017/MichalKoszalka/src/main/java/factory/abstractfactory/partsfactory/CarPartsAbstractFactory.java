package factory.abstractfactory.partsfactory;

import factory.abstractfactory.parts.body.Body;
import factory.abstractfactory.parts.chassis.Chassis;
import factory.abstractfactory.parts.drive.Drive;
import factory.abstractfactory.parts.engine.Engine;
import factory.abstractfactory.parts.turbocharger.TurboCharger;

public interface CarPartsAbstractFactory {

    public Engine createEngine();
    public Chassis createChassis();
    public Body createBody();
    public Drive createDrive();
    public TurboCharger createTurboCharger();

}
