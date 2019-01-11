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

module.exports = {
  Vehicle,
  Car,
  Plane
}