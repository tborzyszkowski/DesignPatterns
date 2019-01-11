const classes = require('../classes');

class VehicleFactory {
  getInstance() {
    let license;
    process.argv.forEach((value) => {
      license = value;
    });
  
    if (license === 'pilot') {
      return new PlaneFactory();
    }
  
    if (license === 'driver') {
      return new CarFactory();
    }
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