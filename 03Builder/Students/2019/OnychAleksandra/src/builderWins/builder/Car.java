package builderWins.builder;

import builderWins.factory.CarBase;

public class Car extends CarBase {

    private Car(Builder builder) {
        this.brand = builder.brand;
        this.model = builder.model;
        this.engine = builder.engine;
        this.productionYear = builder.productionYear;
        this.fuelType = builder.fuelType;
        this.radio = builder.radio;
        this.airConditioning = builder.airConditioning;
    }

    @Override
    public String toString() {
        return "Car{" +
                "brand='" + brand + '\'' +
                ", model='" + model + '\'' +
                ", engine='" + engine + '\'' +
                ", productionYear='" + productionYear + '\'' +
                ", fuelType='" + fuelType + '\'' +
                ", radio=" + radio +
                ", airConditioning=" + airConditioning +
                '}';
    }

    public static class Builder {
        private String brand;
        private String model;
        private String engine;
        private String productionYear;
        private String fuelType;
        private boolean radio;
        private boolean airConditioning;

        public Builder brand(String brand) {
            this.brand = brand;
            return this;
        }

        public Builder model(String model) {
            this.model = model;
            return this;
        }

        public Builder engine(String engine) {
            this.engine = engine;
            return this;
        }

        public Builder productionYear(String productionYear) {
            this.productionYear = productionYear;
            return this;
        }

        public Builder fuelType(String fuelType) {
            this.fuelType = fuelType;
            return this;
        }

        public Builder radio(boolean radio) {
            this.radio = radio;
            return this;
        }

        public Builder airConditioning(boolean airConditioning) {
            this.airConditioning = airConditioning;
            return this;
        }

        public Car build() {
            if (model.isEmpty()) {
                throw new IllegalStateException("Model cannot be empty");
            }
            return new Car(this);
        }
    }
}
