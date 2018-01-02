package prototype.deep;

import java.io.Serializable;

import org.apache.commons.lang3.SerializationUtils;

import com.rits.cloning.Cloner;

import builder.simple.common.BodyType;
import builder.simple.common.ChassisType;
import builder.simple.common.DriveType;
import prototype.common.Engine;

public class Car implements Serializable {

	private static final long serialVersionUID = -2769749703012576290L;

	private String brand;

	private String model;

	private BodyType bodyType;

	private DriveType driveType;

	private Engine engine;

	private ChassisType chassisType;

	public Car() {
	}

	public Car(String brand, String model, BodyType bodyType, DriveType driveType, Engine engine,
			ChassisType chassisType) {
		this.brand = brand;
		this.model = model;
		this.bodyType = bodyType;
		this.driveType = driveType;
		this.engine = engine;
		this.chassisType = chassisType;
	}

	private Car(Car car) {
		brand = car.brand;
		model = car.model;
		bodyType = car.bodyType;
		driveType = car.driveType;
		engine = new Engine(car.engine);
		chassisType = car.chassisType;
	}

	public Car customClone() {
		return new Car(this);
	}

	public Car serializationClone() {
		return SerializationUtils.clone(this);
	}

	public Car deepCloningLibraryClone() {
		return Cloner.shared().deepClone(this);
	}

	public String getBrand() {
		return brand;
	}

	public void setBrand(String brand) {
		this.brand = brand;
	}

	public String getModel() {
		return model;
	}

	public void setModel(String model) {
		this.model = model;
	}

	public BodyType getBodyType() {
		return bodyType;
	}

	public void setBodyType(BodyType bodyType) {
		this.bodyType = bodyType;
	}

	public DriveType getDriveType() {
		return driveType;
	}

	public void setDriveType(DriveType driveType) {
		this.driveType = driveType;
	}

	public ChassisType getChassisType() {
		return chassisType;
	}

	public void setChassisType(ChassisType chassisType) {
		this.chassisType = chassisType;
	}

	public Engine getEngine() {
		return engine;
	}

	public void setEngine(Engine engine) {
		this.engine = engine;
	}
}