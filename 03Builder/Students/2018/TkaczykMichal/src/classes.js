class Vehicle {
  constructor() {
    this.setType = (type) => {
    }

    this.setColor = (color) => {
    }

    this.setEngine = (engine) => {
    }
  }
}

class Car extends Vehicle {
  constructor() {
    super();
    this.type = 'Car';

    this.setColor = (color) => {
      this.color = color;
    }

    this.setEngine = (engine) => {
      this.engine = engine;
    }
  }
}

class Plane extends Vehicle {
  constructor() {
    super();
    this.type = 'Plane';

    this.setColor = (color) => {
      this.color = color;
    }

    this.setEngine = (engine) => {
      this.engine = engine;
    }
  }
}

module.exports = {
  Vehicle,
  Car,
  Plane
}