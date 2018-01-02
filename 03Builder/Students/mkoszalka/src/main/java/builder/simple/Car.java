package builder.simple;

import builder.simple.common.BodyType;
import builder.simple.common.ChassisType;
import builder.simple.common.DriveType;
import builder.simple.common.FuelType;

public class Car {

    private String brand;

    private String model;

    private FuelType fuelType;

    private BodyType bodyType;

    private DriveType driveType;

    private ChassisType chassisType;

    private Car(CarBuilder carBuilder){
		brand = carBuilder.brand;
		model = carBuilder.model;
		fuelType = carBuilder.fuelType;
		driveType = carBuilder.driveType;
		chassisType = carBuilder.chassisType;
		bodyType = carBuilder.bodyType;
	}

    public String getBrand() {
        return brand;
    }

    public String getModel() {
        return model;
    }

    public FuelType getFuelType() {
        return fuelType;
    }

    public BodyType getBodyType() {
        return bodyType;
    }

    public DriveType getDriveType() {
        return driveType;
    }

    public ChassisType getChassisType() {
        return chassisType;
    }

    public static class CarBuilder {

        private String brand;

        private String model;

        private FuelType fuelType;

        private BodyType bodyType;

        private DriveType driveType;

        private ChassisType chassisType;

        public CarBuilder withBrand(String brand) {
            this.brand = brand;
            return this;
        }

        public CarBuilder withModel(String model) {
            this.model = model;
            return this;
        }

        public CarBuilder withFuelType(FuelType fuelType) {
            this.fuelType = fuelType;
            return this;
        }

        public CarBuilder withDriveType(DriveType driveType) {
            this.driveType = driveType;
            return this;
        }

        public CarBuilder withChasisType(ChassisType chassisType) {
            this.chassisType = chassisType;
            return this;
        }

        public CarBuilder withBodyType(BodyType bodyType) {
            this.bodyType = bodyType;
            return this;
        }

        public Car build() {
            return new Car(this);
        }


    }
}
