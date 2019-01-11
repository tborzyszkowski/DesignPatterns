let vehicleFactoryInstance = null;

class Vehicle {
  constructor(engine = 'normal engine') {
    this.engine = engine;
  }
}

class Car {
  constructor(doors = 4, color = 'black', engine = '2.0 TDI') {
    this.type = 'Car';
    this.doors = doors;
    this.color = color;
    this.engine = engine;
  }
}

class Plane {
  constructor(seats = 100, color = 'white', engine = 'Austro Engine AE50R') {
    this.type = 'Plane';
    this.seats = seats;
    this.color = color;
    this.engine = engine;
  }
}

class VehicleFactory {
  constructor() {
    if (!vehicleFactoryInstance) {
      vehicleFactoryInstance = this;
    }

    this.createVehicle = (properties) => {
      return new Vehicle(properties.engine);
    }

    return vehicleFactoryInstance;
  }
}

class CarFactory extends VehicleFactory {
  constructor() {
    super();
    this.createVehicle = (properties) => {
      return new Car(properties.doors, properties.color, properties.engine);
    }
  }
}

class PlaneFactory extends VehicleFactory {
  constructor() {
    super();
    this.createVehicle = (properties) => {
      return new Plane(properties.seats, properties.color, properties.engine);
    }
  }
}

module.exports = {
  VehicleFactory,
  CarFactory,
  PlaneFactory
};