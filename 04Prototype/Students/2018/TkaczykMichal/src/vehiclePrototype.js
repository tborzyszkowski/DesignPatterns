'use strict';

class Vehicle {
  constructor(Vehicle) {}

  Clone() {}
}

class ConcreteVehicle1 extends Vehicle {
  constructor() {
    console.log("ConcreteVehicle1 created");
    super()
    this.feature = "feature 1"
  }

  setFeature(key, val) {
    this[key] = val
  }

  Clone() {
    console.log('custom cloning function')
    let clone = new ConcreteVehicle1()
    let keys = Object.keys(this)

    keys.forEach(k => clone.setFeature(k, ...this[k]));

    console.log("ConcreteVehicle1 cloned");
    return clone;
  }
}

class ConcreteVehicle2 extends Vehicle {
  constructor() {
    console.log("ConcreteVehicle2 created");
    super()
  }

  Clone() {
    console.log("ConcreteVehicle2 cloned");
    return clone;
  }
}

function init_Vehicle() {
  var proto1 = new ConcreteVehicle1()
  proto1.setFeature('feature', "feature 22")
  var clone1 = proto1.Clone()
  console.log(clone1.feature)
}