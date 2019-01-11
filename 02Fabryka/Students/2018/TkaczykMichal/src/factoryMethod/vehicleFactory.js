const classes = require('../classes');

let vehicleFactoryInstance = null;

class VehicleFactory {
  constructor() {
    if (!vehicleFactoryInstance) {
      vehicleFactoryInstance = this;
    }

    this.createVehicle = (properties) => {
      return new classes.Vehicle(properties.engine);
    }

    return vehicleFactoryInstance;
  }
}

class CarFactory extends VehicleFactory {
  constructor() {
    super();
    this.createVehicle = (properties) => {
      return new classes.Car(properties.doors, properties.color, properties.engine);
    }
  }
}

class PlaneFactory extends VehicleFactory {
  constructor() {
    super();
    this.createVehicle = (properties) => {
      return new classes.Plane(properties.seats, properties.color, properties.engine);
    }
  }
}

module.exports = {
  VehicleFactory,
  CarFactory,
  PlaneFactory
};