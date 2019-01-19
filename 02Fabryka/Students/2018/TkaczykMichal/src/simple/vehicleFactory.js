const classes = require('../classes');

let vehicleFactoryInstance = null;

class VehicleFactory {
  constructor() {
    if (!vehicleFactoryInstance) {
      vehicleFactoryInstance = this;
    }

    this.createVehicle = (type, properties) => {
      switch (type) {
        case 'car':
          return new classes.Car(properties.doors, properties.color, properties.engine);
        case 'plane':
          return new classes.Plane(properties.seats, properties.color, properties.engine);
      }
    }

    return vehicleFactoryInstance;
  }
}

module.exports = {
  VehicleFactory
};
