
let vehicleFactoryInstance = null;

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
    if(!vehicleFactoryInstance) {
      vehicleFactoryInstance = this;
    }

    this.createVehicle = (type, properties) => {
      switch (type) {
        case 'car':
          return new Car(properties.doors, properties.color, properties.engine);
        case 'plane':
          return new Plane(properties.seats, properties.color, properties.engine);
      }
    }

    return vehicleFactoryInstance;
  }
}

module.exports = {
  Car,
  Plane,
  VehicleFactory
};
